using System;

namespace Application.Requests.Friend
{
    public class AddFriendRequest
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string FriendId { get; set; }
    }
}
