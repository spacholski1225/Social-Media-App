using Application.Requests.Friend;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Routes;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IActionResult AddFriendAsync([FromBody] AddFriendRequest request)
        {
            var friend = new Friend
            {
                FriendId = request.FriendId,
                UserId = request.UserId,
            };
            _friendRepository.AddFriend(friend);
            return Ok();
        }
        //endpoint to remove friend from list
        //endpoint to get friend and check his profile
        //endpoint to get all friends
    }
}
