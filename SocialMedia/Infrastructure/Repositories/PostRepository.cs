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
            return post;
        }

        public Post UpdatePost(string id)
        {
            throw new NotImplementedException();
        }
        public bool DeletePost(string id)
        {
            throw new NotImplementedException();
        }


    }
}
