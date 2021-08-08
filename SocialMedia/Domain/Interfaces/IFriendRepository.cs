using Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFriendRepository
    {
        public bool AddFriend(Friend friend);
        public bool DeleteFriend(Friend friend);
        public bool IsFriend(string userId, string friendId);
        public Task<Friend> FindFriendIdByUserIdAsync(string FriendId, ClaimsPrincipal user);
        public List<Friend> GetAllFriends(string userId);
    }
}
