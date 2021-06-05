using Application.Requests.Post;
using Application.Responses;
using Domain.Entities;
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
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly AutoMapperConfig _mapper;

        public PostController(IPostRepository postRepository, AutoMapperConfig mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        [HttpPost]
        [Route(ApiRoutes.PostRoutes.CreatePost)]
        public IActionResult CreatePost([FromBody] CreatePostRequest request)
        {
            var post = new Post //add auto mapper
            {
                Id = new Guid(),
                Name = request.Name
            };
            var result = _postRepository.CreatePost(post);
            if (!result)
            {
                return BadRequest(new PostResponse
                {
                    Errors = new[] { "Can not add new post" } // change it to something else maybe to kind of response
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
            var post = new Post // add automapper
            {
                Id = postId,
                Name = request.Name
            };
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
    }
}
