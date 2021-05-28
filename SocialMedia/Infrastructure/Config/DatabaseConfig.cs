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
    }
}
