using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IPostRepository
    {
        public Post CreatePost();
        public List<Post> GetPosts();
        public Post GetPost(string id);
        public Post UpdatePost(string id);
        public void DeletePost(string id);
    }
}
