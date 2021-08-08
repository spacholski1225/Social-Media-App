using Application.Requests.Friend;
using Application.Responses.Friend;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Routes;

namespace WebAPI.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class FriendController : ControllerBase
    {
        private readonly IFriendRepository _friendRepository;

        public FriendController(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }
        //endpoint with adding to list of friends
        [HttpPost]
        [Route(ApiRoutes.FriendRoutes.AddFriend)]
        public async Task<IActionResult> AddFriendAsync([FromBody] GetFriendIdRequest request)
        {
            //add checking if friend alreade exist
            var friend = await _friendRepository.FindFriendIdByUserIdAsync(request.FriendId, HttpContext.User);

            var result = _friendRepository.AddFriend(friend);
            if (!result)
            {
                return BadRequest(new FriendResponse
                {
                    Errors = new[] { "Cannot add a new post" }
                });
            }
            return Ok();
        }
        //endpoint to remove friend from list
        [HttpPost]
        [Route(ApiRoutes.FriendRoutes.DeleteFriend)]
        public async Task<IActionResult> DeleteFriendAsync([FromBody] GetFriendIdRequest request)
        {
            var friend = await _friendRepository.FindFriendIdByUserIdAsync(request.FriendId, HttpContext.User);

            var result = _friendRepository.DeleteFriend(friend);
            if (!result)
            {
                return BadRequest(new FriendResponse
                {
                    Errors = new[] { "Cannot delete this frend from list" }
                });
            }
            return Ok();
        }
        [HttpGet]
        [Route(ApiRoutes.FriendRoutes.GetListOfFriends)]
        public IActionResult GetListOfFriends([FromBody] GetUserIdRequest request)
        {
            var friendsList = _friendRepository.GetAllFriends(request.UserId);
            if(friendsList.Count == 0 || friendsList == null)
            {
                return BadRequest(new FriendResponse
                {
                    Errors = new[] { "Cannot find any friends." }
                });
            }
            return Ok(friendsList);
        }
    }
}
