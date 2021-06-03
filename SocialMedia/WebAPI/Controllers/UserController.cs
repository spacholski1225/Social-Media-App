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
        // GET: api/<UserController>
        [HttpGet]
        [Route(ApiRoutes.UserRoutes.GetAll)]
        public OkObjectResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet]
        [Route(ApiRoutes.UserRoutes.GetByUserName)]
        public async Task<IActionResult> GetUserByUserName(string username)
        {
            var user = await _userRepository.GetUserByUserName(username);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // PUT api/<UserController>/5
        [HttpPut]
        [Route(ApiRoutes.UserRoutes.UpdateUser)]
        public async Task<IActionResult> UpdateUser([FromBody] IdentityUser identityUser, string username)
        {
            await _userRepository.UpdateUserAsync(username, identityUser);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete]
        [Route(ApiRoutes.UserRoutes.DeleteUser)]
        public async Task<IActionResult> DeleteUser(string username)
        {
             await _userRepository.DeleteUserByUserName(username);
            return Ok();
        }
    }
}
