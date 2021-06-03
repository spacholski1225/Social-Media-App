using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
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
        public OkObjectResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserByUserName(string username)
        {
            var user = await _userRepository.GetUserByUserName(username);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{username}")]
        public async Task<IActionResult> UpdateUser([FromBody] IdentityUser identityUser, string username)
        {
            await _userRepository.UpdateUserAsync(username, identityUser);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
             await _userRepository.DeleteUserByUserName(username);
            return Ok();
        }
    }
}
