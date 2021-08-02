using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IFriendRepository
    {
        public bool AddFriend(Friend friend);
        public bool DeleteFriend(Friend friend);
    }
}
