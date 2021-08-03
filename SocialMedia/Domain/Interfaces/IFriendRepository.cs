using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Interfaces
{
    public interface IFriendRepository
    {
        public bool AddFriend(Friend friend);
        public bool DeleteFriend(Friend friend);
        public bool IsFriend(string userId, string friendId);
    }
}
