using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Routes;

namespace WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        [Route(ApiRoutes.UserRoutes.GetAll)]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            if(users == null)
            {
                return BadRequest();
            }
            return Ok(users);
        }

        [HttpGet]
        [Route(ApiRoutes.UserRoutes.GetByUserName)]
        public async Task<IActionResult> GetUserByUserName([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUserName(username);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPut]
        [Route(ApiRoutes.UserRoutes.UpdateUser)]
        public async Task<IActionResult> UpdateUser([FromBody] IdentityUser identityUser, string username)
        {
            await _userRepository.UpdateUserAsync(username, identityUser);
            return Ok();
        }

        [HttpDelete]
        [Route(ApiRoutes.UserRoutes.DeleteUser)]
        public async Task<IActionResult> DeleteUser([FromRoute] string username)
        {
             await _userRepository.DeleteUserByUserName(username);
            return Ok();
        }
    }
}
