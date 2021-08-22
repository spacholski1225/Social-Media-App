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
        public Task<bool> UpdatePostAsync(Post postToUpdate);
        public Task<bool> DeletePostAsync(Guid id);
        public Task<bool> UserOwnsPostAsync(Guid postId, string userId);
        public Task<Comments> DisplayPostComments(Guid postId);
        public bool AddCommentToPost(Comments comment);
    }
}
