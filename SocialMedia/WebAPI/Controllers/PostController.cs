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
                    Errors = new[] { "Can not add new post" }
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
    }
}
