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
        private readonly UserManager<IdentityUser> userManager; //stworzyc funkcje w identityservice

        public FriendController(IFriendRepository friendRepository, UserManager<IdentityUser> userManager )
        {
            _friendRepository = friendRepository;
            this.userManager = userManager;
        }
        //endpoint with adding to list of friends
        [HttpPost]
        [Route(ApiRoutes.FriendRoutes.AddFriend)]
        public async Task<IActionResult> AddFriendAsync([FromBody] AddFriendRequest request)
        {
            var username = userManager.GetUserId(HttpContext.User); //there should be returned userId but output value is username
            var userId = await userManager.FindByNameAsync(username);
            var potentialFriend = await userManager.FindByIdAsync(request.FriendId);
            var friend = new Friend
            {
                FriendId = potentialFriend.Id,
                UserId = userId.Id
            };

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
        public async Task<IActionResult> DeleteFriendAsync([FromBody] DeleteFriendRequest request)
        {
            var username = userManager.GetUserId(HttpContext.User); //there should be returned userId but output value is username
            var user = await userManager.FindByNameAsync(username);

            var friend = new Friend
            {
                FriendId = request.FriendId,
                UserId = user.Id
            };
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
    }
}
