using Application.Requests.Post;
using Application.Responses;
using Domain.Entities;
using Domain.Extensions;
using Domain.Interfaces;
using Infrastructure.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Routes;

namespace WebAPI.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpPost]
        [Route(ApiRoutes.PostRoutes.CreatePost)]
        public IActionResult CreatePost([FromBody] CreatePostRequest request)
        {
            var post = new Post
            {
                Id = new Guid(),
                Name = request.Name,
                UserId = HttpContext.GetUserId(),
                Date = DateTime.Now

            };
            var result = _postRepository.CreatePost(post);
            if (!result)
            {
                return BadRequest(new PostResponse
                {
                    Errors = new[] { "Cannot add a new post" } 
                });
            }
            return Ok();
        }
        [HttpGet]
        [Route(ApiRoutes.PostRoutes.GetPosts)]
        public async Task<List<Post>> GetPosts()
        {
            return await _postRepository.GetPostsAsync();
        }

        [HttpGet]
        [Route(ApiRoutes.PostRoutes.GetPostById)]
        public async Task<Post> GetPosts([FromRoute]Guid postId)
        {
            return await _postRepository.GetPostAsync(postId);
        }

        [HttpPut]
        [Route(ApiRoutes.PostRoutes.UpdatePost)]
        public async Task<IActionResult> UpdatePost([FromRoute]Guid postId, [FromBody] UpdatePostRequest request)
        {
            var userOwnsPost = await _postRepository.UserOwnsPostAsync(postId, HttpContext.GetUserId());

            if (!userOwnsPost)
            {
                return BadRequest(new { error = " You do not own this post" });
            }
            var post = await _postRepository.GetPostAsync(postId);
            post.Name = request.Name;
            
            var updated = await _postRepository.UpdatePostAsync(post);
            if (!updated)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete]
        [Route(ApiRoutes.PostRoutes.DeletePost)]
        public async Task<IActionResult> DeletePost([FromRoute]Guid postId)
        {
            var userOwnsPost = await _postRepository.UserOwnsPostAsync(postId, HttpContext.GetUserId());

            if (!userOwnsPost)
            {
                return BadRequest(new { error = " You do not own this post" });
            }
            var deleted = await _postRepository.DeletePostAsync(postId);
            if (!deleted)
            {
                return BadRequest(new DeletePostRequest
                {
                    Errors = new[] { "Cannot delete post" }
                });
            }
            return Ok();
        }

        [HttpGet]
        [Route(ApiRoutes.PostRoutes.LatestPosts)]
        public async Task<List<Post>> DisplayPostsFromTheLastest()
        {
            var posts = await _postRepository.GetPostsAsync();
            var latestPosts = posts.OrderBy(x => x.Date).ToList();
            return latestPosts;
        }
        [HttpPost]
        [Route(ApiRoutes.PostRoutes.AddComment)]
        public IActionResult AddCommentToPost([FromBody] CommentPostRequest request)
        {
            var comment = new Comments
            {
                PostId = request.PostId,
                Author = HttpContext.GetUserId(),
                Comment = request.Comment,
                Id = new Guid()
            };
            var result = _postRepository.AddCommentToPost(comment);
            if(result)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { error = "Cannot add your comment." });
            }
            
        }
        [HttpGet]
        [Route(ApiRoutes.PostRoutes.DisplayComments)]
        public List<Comments> DisplayPostComments([FromBody] CommentPostRequest request)
        {
            return _postRepository.DisplayPostComments(request.PostId);
        }
    }
}
