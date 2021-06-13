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
        public async Task Register_ReturnSuccessResult()
        {
            //Arrange
            _identityServiceMock.Setup(s => s.RegisterAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new AuthenticationResult());
            //Act
            var result = await _controller.Register(new UserRegistrationRequest());
            //Assert
            Assert.IsType<AuthenticationResult>(result);
            Assert.NotNull(result);
        }
    }
}
