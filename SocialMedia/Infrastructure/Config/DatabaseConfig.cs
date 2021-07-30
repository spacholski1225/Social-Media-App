using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Config
{
    public class DatabaseConfig : IdentityDbContext<IdentityUser>
    {
        public DatabaseConfig(DbContextOptions<DatabaseConfig> options)
        : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; } 
        public DbSet<Friend> Friends { get; set; }
        public DbSet<RefreshToken> RefreshTokens{ get; set; } 
    }
}
