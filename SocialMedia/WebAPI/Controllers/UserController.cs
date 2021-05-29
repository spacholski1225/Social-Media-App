using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
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

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] IdentityUser identityUser, string password)
        {
            await _userRepository.CreateUser(identityUser, password);
            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("{username}")]
        public IActionResult UpdateUser([FromBody] IdentityUser identityUser, string username)
        {
            _userRepository.UpdateUser(username, identityUser);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{username}")]
        public IActionResult DeleteUser(string username)
        {
             _userRepository.DeleteUserByUserName(username);
            return Ok();
        }
        
    }
}
