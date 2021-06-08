using Application.Requests;
using Application.Responses;
using Domain.Entities;
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
            return AuthResultIsSuccess(authResponse);
        }
        [HttpPost]
        [Route(ApiRoutes.IdentityRoutes.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var authResponse = await _identityService.LoginAsync(request.Email, request.Password);
                return AuthResultIsSuccess(authResponse);
            }
            return BadRequest(new AuthFailedResponse
            {
                Errors = new[] { "Invalid payload" }
            });

        }
        [HttpPost(ApiRoutes.IdentityRoutes.Refresh)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var response = await _identityService.RefreshTokenAsync(request.Token, request.RefreshToken);

            return AuthResultIsSuccess(response);
        }
        private IActionResult AuthResultIsSuccess(AuthenticationResult response)
        {
            if (!response.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = response.Errors
                });
            }
            return Ok(new AuthSuccessResponse
            {
                Token = response.Token,
                RefreshToken = response.RefreshToken
            });
        }
    }
}
