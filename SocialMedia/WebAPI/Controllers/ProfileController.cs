using Application.Interfaces;
using Application.Responses.Profile;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using WebAPI.Routes;

namespace WebAPI.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IFriendRepository _friendRepository;
        public ProfileController(IProfileRepository profileRepository,
            IFriendRepository friendRepository)
        {
            _profileRepository = profileRepository;
            _friendRepository = friendRepository;
        }
      
        [Route(ApiRoutes.ProfileRoutes.GetFriendProfile)]
        [HttpGet]
        public async Task<IActionResult> GetFriendProfile([FromRoute] string friendId)
        {
            var friend = await _friendRepository.FindFriendIdByUserIdAsync(friendId, HttpContext.User);

            if (_friendRepository.IsFriend(friend.UserId, friendId))
            {
                var friendIdentity = await _profileRepository.GetUserProfileByIdAsync(friend.FriendId);
                return Ok(friendIdentity);
            }
            else
            {
                return BadRequest(new ProfileResponse
                {
                    Errors = new[] { "You can check only friends profiles!" }
                });
            }
        }
    }
}
