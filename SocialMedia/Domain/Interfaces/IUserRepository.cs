using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task UpdateUserAsync(string username, IdentityUser identityUser);
        public List<IdentityUser> GetUsers();
        public Task<IdentityUser> GetUserByUserNameAsync(string username);
        public Task DeleteUserByUserNameAsync(string username);
        public Task<IdentityUser> GetUserByIdAsync(string id);
    }
}
