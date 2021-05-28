using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Config;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseConfig _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(DatabaseConfig context, UserManager<IdentityUser> userManager, ILogger<UserRepository> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
        public async Task CreateUser(IdentityUser user, string password)
        {
            try
            {
                await _userManager.CreateAsync(user, password);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurs during creating new user error: " + ex.Message);
            }
        }

        public async void UpdateUser(string username, IdentityUser identityUser)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                user.UserName = identityUser.UserName; //change to automapper
            }
            await _userManager.UpdateAsync(user);
        }

        public List<IdentityUser> GetUsers()
        {
            return _userManager.Users.ToList();
        }
        public async Task<IdentityUser> GetUserByUserName(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async void DeleteUserByUserName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
                await _userManager.DeleteAsync(user);
        }

    }
}
