using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
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
        
    }
}
