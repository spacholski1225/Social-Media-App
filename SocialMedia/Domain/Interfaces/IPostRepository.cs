using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPostRepository
    {
        public bool CreatePost(Post post);
        public Task<List<Post>> GetPostsAsync();
        public Task<Post> GetPostAsync(Guid id);
        public Post UpdatePost(string id);
        public bool DeletePost(string id);
    }
}
