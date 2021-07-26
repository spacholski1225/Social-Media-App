using Application.Requests.Post;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace SocialMedia.Test
{
    public class PostControllerTest
    {
        private readonly PostController _controller;
        private readonly Mock<IPostRepository> _mockPostRepository;
        public PostControllerTest()
        {
            
            _mockPostRepository = new Mock<IPostRepository>();
            _controller = new PostController(_mockPostRepository.Object);
        }

        [Fact(Skip ="httpcontext problem ")]
        public void CreatePost_ReturnOkResult_WhenCreatedPost()
        {
            //Arrange
            _mockPostRepository.Setup(s => s.CreatePost(It.IsAny<Post>())).Returns(true);
            
            //Act
            var result = _controller.CreatePost(new CreatePostRequest { Name = "test" });
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact(Skip = "httpcontext problem ")]
        public async Task UpdatePost_ReturnBadRequest_ForUptadedNotOwnPost()
        {
            //Arrange
            _mockPostRepository.Setup(s => s.UserOwnsPostAsync(It.IsAny<Guid>(), It.IsAny<string>())).ReturnsAsync(false);
            //Act
            var result = await _controller.UpdatePost(new Guid(), new UpdatePostRequest());
            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        //finish it after fixing httpcontext mock

    }
}
