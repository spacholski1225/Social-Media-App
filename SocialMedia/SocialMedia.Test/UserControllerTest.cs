using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace SocialMedia.Test
{
    public class UserControllerTest
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly UserController _controller;
        public UserControllerTest()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _controller = new UserController(_mockUserRepository.Object);
        }
        [Fact]
        public void GetUsers_ReturnedBadRequest_WhenCannotFindUsers()
        {
            //Arrange
            _mockUserRepository.Setup(s => s.GetUsers()).Returns(() => null);
            //Act
            var result = _controller.GetUsers();
            //Assert
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public void GetUsers_ReturnedOkResult_WhenFindUsers()
        {
            //Arrange
            _mockUserRepository.Setup(s => s.GetUsers()).Returns(new List<IdentityUser>());
            //Act
            var result = _controller.GetUsers();
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetUserByUserName_ReturnNotFound_ForUserEqualNull()
        {
            //Arrange
            _mockUserRepository.Setup(s => s.GetUserByUserName(It.IsAny<string>())).ReturnsAsync(() => null);
            //Act
            var result = await _controller.GetUserByUserName("test");
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task GetUserByUserName_ReturnUser_ForUserNotNull()
        {
            //Arrange
            _mockUserRepository.Setup(s => s.GetUserByUserName(It.IsAny<string>())).ReturnsAsync(new IdentityUser());
            //Act
            var result = await _controller.GetUserByUserName("test");
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        
    }
}
