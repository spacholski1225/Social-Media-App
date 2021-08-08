using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace SocialMedia.Test
{
    public class ProfileControllerTest
    {
        private readonly ProfileController _controller;
        private readonly Mock<IProfileRepository> _mockProfileRepository;

        //Change after modify method in controller
        public ProfileControllerTest()
        {
            _mockProfileRepository = new Mock<IProfileRepository>();
            //_controller = new ProfileController(_mockProfileRepository.Object);
        }
        
        [Fact]
        public async Task GetProfile_ReturnOkResult_WhenProfileIsNotNull()
        {
            //Arrange
            _mockProfileRepository.Setup(s => s.GetUserProfileByUsernameAsync(It.IsAny<string>())).ReturnsAsync(new ProfileDto());
            //Act
            var result = await _controller.GetProfile("test");
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetProfile_ReturnBadResult_WhenProfileIsNull()
        {
            //Arrange
            _mockProfileRepository.Setup(s => s.GetUserProfileByUsernameAsync(It.IsAny<string>())).ReturnsAsync(() => null);
            //Act
            var result = await _controller.GetProfile("test");
            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
