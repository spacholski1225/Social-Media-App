using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Config;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private readonly DatabaseConfig _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FriendRepository(DatabaseConfig context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public bool AddFriend(Friend friend)
        {
            try
            {
                _context.Friends.Add(friend);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteFriend(Friend friend)
        {
            var friendToRemove = _context.Friends.FirstOrDefault(x => x.FriendId == friend.FriendId && x.UserId == friend.UserId);
            try
            {
                _context.Friends.Remove(friendToRemove);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsFriend(string userId, string friendId)
        {
            var result = _context.Friends.FirstOrDefault(x => x.UserId == userId);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<Friend> FindFriendIdByUserIdAsync(string FriendId, ClaimsPrincipal user)
        {
            var username = _userManager.GetUserId(user); 
            var userId = await _userManager.FindByNameAsync(username);
            var potentialFriend = await _userManager.FindByIdAsync(FriendId);
            return new Friend
            {
                FriendId = potentialFriend.Id,
                UserId = userId.Id
            };
        }
    }
}
