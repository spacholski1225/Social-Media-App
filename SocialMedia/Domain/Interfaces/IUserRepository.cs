using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task CreateUser(IdentityUser user, string password);
        public Task UpdateUser(string username, IdentityUser identityUser);
        public List<IdentityUser> GetUsers();
        public Task<IdentityUser> GetUserByUserName(string username);
        public Task DeleteUserByUserName(string username);
    }
}
