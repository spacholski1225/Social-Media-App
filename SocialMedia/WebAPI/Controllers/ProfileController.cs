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
        private readonly UserManager<IdentityUser> userManager; //stworzyc funkcje w identityservice

        public ProfileController(IProfileRepository profileRepository,
            IFriendRepository friendRepository, UserManager<IdentityUser> userManager)
        {
            _profileRepository = profileRepository;
            _friendRepository = friendRepository;
            this.userManager = userManager;
        }
        [Route(ApiRoutes.ProfileRoutes.GetProfile)]
        [HttpGet]
        public async Task<IActionResult> GetProfile([FromRoute] string username)
        {
            var profile = await _profileRepository.GetUserProfileAsync(username);
            if (profile == null)
            {
                return BadRequest(new ProfileResponse
                {
                    Errors = new[] { "User cannot be found" }
                });
            }
            return Ok(profile);
        }
        [Route(ApiRoutes.ProfileRoutes.GetFriendProfile)]
        public async Task<IActionResult> GetFriendProfile([FromBody] string friendId)
        {
            var username = userManager.GetUserId(HttpContext.User); //there should be returned userId but output value is username
            var userId = await userManager.FindByNameAsync(username);

            if (_friendRepository.IsFriend(userId.Id, friendId))
            {
                var potentialFriend = await userManager.FindByIdAsync(friendId);
                return Ok(await _profileRepository.GetUserProfileAsync(potentialFriend.UserName));
            }
            else
            {
                return BadRequest(new ProfileResponse
                {
                    Errors = new[] { "User cannot be found" }
                });
            }
        }
        //endpoint to get friend and check his profile
        /* zastanowic sie w jakis sposob zrobic pobieranie informacji o danym koledze zeby przejrzec jego profil
         * mysle ze to powinno byc w profilecontroller i tam w jakis sposob pobiera dla danego uzytkownika id szukanego frienda
         * i wtedy te Id podaje dalej
       */
        //endpoint to get all friends

    }
}
