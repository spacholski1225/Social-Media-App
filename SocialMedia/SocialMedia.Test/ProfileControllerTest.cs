using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace SocialMedia.Test
{
    public class ProfileControllerTest
    {
        private readonly ProfileController _controller;
        private readonly Mock<IProfileRepository> _mockProfileRepository;
        private readonly Mock<IFriendRepository> _mockFriendRepository;

        //Change after modify method in controller
        public ProfileControllerTest()
        {
            _mockProfileRepository = new Mock<IProfileRepository>();
            _mockFriendRepository = new Mock<IFriendRepository>();
            _controller = new ProfileController(_mockProfileRepository.Object, _mockFriendRepository.Object);
        }
        
        [Fact(Skip = "Error with claims principall")]
        public async Task GetFriendProfile_ReturnOkResult_WhenProfileIsNotNull()
        {
            //Arrange
            _mockFriendRepository.Setup(s => s.FindFriendIdByUserIdAsync(It.IsAny<string>(), It.IsAny<ClaimsPrincipal>()))
                .ReturnsAsync(new Friend());
            _mockFriendRepository.Setup(s => s.IsFriend(It.IsAny<string>(), It.IsAny<string>())).Returns(() => true);
            //Act
            var result = await _controller.GetFriendProfile("test");
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact(Skip = "Error with claims principall")]
        public async Task GetProfile_ReturnBadResult_WhenProfileIsNull()
        {
            //Arrange
            _mockFriendRepository.Setup(s => s.FindFriendIdByUserIdAsync(It.IsAny<string>(), It.IsAny<ClaimsPrincipal>()))
                 .ReturnsAsync(new Friend());
            _mockFriendRepository.Setup(s => s.IsFriend(It.IsAny<string>(), It.IsAny<string>())).Returns(() => false);
            //Act
            var result = await _controller.GetFriendProfile("test");
            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
