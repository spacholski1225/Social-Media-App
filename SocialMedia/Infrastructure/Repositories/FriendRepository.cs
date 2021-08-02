using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private readonly DatabaseConfig _context;

        public FriendRepository(DatabaseConfig context)
        {
            _context = context;
        }
        public bool AddFriend(Friend friend)
        {
            try
            {
                _context.Friends.Add(friend);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
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
    }
}
