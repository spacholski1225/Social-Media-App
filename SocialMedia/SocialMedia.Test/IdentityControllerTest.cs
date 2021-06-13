using Application.Requests;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace SocialMedia.Test
{
    public class IdentityControllerTest
    {
        private readonly Mock<IIdentityService> _identityServiceMock;
        private readonly IdentityController _controller;
        public IdentityControllerTest()
        {
            _identityServiceMock = new Mock<IIdentityService>();
            _controller = new IdentityController(_identityServiceMock.Object);
        }

        [Fact]
        public async Task Register_ReturnOkResult()
        {
            //Arrange
            _identityServiceMock.Setup(s => s.RegisterAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new AuthenticationResult {Success = true });
            
            //Act
            var result = await _controller.Register(new UserRegistrationRequest());
            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
        }
        [Fact]
        public async Task Register_ReturnBadResult()
        {
            //Arrange
            _identityServiceMock.Setup(s => s.RegisterAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new AuthenticationResult { Success = false });

            //Act
            var result = await _controller.Register(new UserRegistrationRequest());
            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(result);
        }
        [Fact]
        public async Task Login_ReturnOkResult_WhenModelIsValid()
        {
            //Arrange
            _identityServiceMock.Setup(s=> s.LoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new AuthenticationResult { Success = true });
            //Act
            var result = await _controller.Login(new UserLoginRequest());
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Login_ReturnBadResult_WhenModelIsValid()
        {
            //Arrange
            _identityServiceMock.Setup(s => s.LoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new AuthenticationResult { Success = false });
            //Act
            var result = await _controller.Login(new UserLoginRequest());
            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
