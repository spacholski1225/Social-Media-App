using Application.Requests;
using Application.Responses;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Routes;

namespace WebAPI.Controllers
{
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        [HttpPost]
        [Route(ApiRoutes.IdentityRoutes.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);
            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }
            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });
        }
        [HttpPost]
        [Route(ApiRoutes.IdentityRoutes.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var authResponse = await _identityService.LoginAsync(request.Email, request.Password);
                if (!authResponse.Success)
                {
                    return BadRequest(new AuthFailedResponse
                    {
                        Errors = authResponse.Errors
                    });
                }
                return Ok(new AuthSuccessResponse
                {
                    Token = authResponse.Token
                });
            }
            return BadRequest(new AuthFailedResponse
            {
                Errors = new[] { "Invalid payload" }
            });

        }
    }
}
