using Application.Requests.Friend;
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
    public class FriendControllerTest
    {
        private readonly FriendController _controller;
        private readonly Mock<IFriendRepository> _mockFriendRepository;
        public FriendControllerTest()
        {
            _mockFriendRepository = new Mock<IFriendRepository>();

            _controller = new FriendController(_mockFriendRepository.Object);
        }
        [Fact]
        public void GetListOfFriends_ReturnBadRequest_WhenFriendListIsEmpty()
        {
            //Arrange
            _mockFriendRepository.Setup(s => s.GetAllFriends(It.IsAny<string>())).Returns(new List<Friend>());
            //Act
            var result = _controller.GetListOfFriends(new GetUserIdRequest());
            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public void GetListOfFriends_ReturnOkResult_WhenFriendListIsNotEmpty()
        {
            //Arrange
            _mockFriendRepository.Setup(s => s.GetAllFriends(It.IsAny<string>())).Returns(new List<Friend>
            { new Friend() });
            //Act
            var result = _controller.GetListOfFriends(new GetUserIdRequest());
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

    }
}
