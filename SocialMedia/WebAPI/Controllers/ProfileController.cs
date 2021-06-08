using Application.Interfaces;
using Application.Responses.Profile;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        public ProfileController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        [Route(ApiRoutes.ProfileRoutes.GetProfile)]
        public async Task<IActionResult> GetProfile([FromRoute] string username)
        {
            var profile = await _profileRepository.GetUserProfileAsync(username);
            if(profile == null)
            {
                return BadRequest(new ProfileResponse
                {
                    Errors = new[] { "User cannot be found" }
                });
            }
            return Ok(profile);
        }

    }
}
