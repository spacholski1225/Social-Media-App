using Application.Responses;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DatabaseConfig _context;

        public PostRepository(DatabaseConfig context)
        {
            _context = context;
        }
        public bool CreatePost(Post post)
        {
            try
            {
                _context.Posts.Add(post);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<Post>> GetPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }
        public async Task<Post> GetPostAsync(Guid id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(s => s.Id == id);
            if (post == null)
            {
                return null;
            }
            return post;
        }

        public async Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            var exist = await GetPostAsync(postToUpdate.Id);
            if (exist == null)
            {
                return false;
            }
            exist.Name = postToUpdate.Name; // refactor it and add automapper
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeletePostAsync(Guid id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(s => s.Id == id);
            try
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UserOwnsPostAsync(Guid postId, string userId)
        {
            var post = await _context.Posts.AsNoTracking().SingleOrDefaultAsync(x => x.Id == postId);
            if (post == null)
            {
                return false;
            }
            if(post.UserId != userId)
            {
                return false;
            }
            return true;
        }
    }
}
