using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {

        }
        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(string username)
        {
            throw new NotImplementedException();
        }

        public User GetUsers()
        {
            throw new NotImplementedException();
        }
        public User GetUserByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserByUserName(string username)
        {
            throw new NotImplementedException();
        }

    }
}
