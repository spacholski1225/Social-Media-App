using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        public void CreateUser(User user);
        public User UpdateUser(string username);
        public User GetUsers();
        public User GetUserByUserName(string username);
        public void DeleteUserByUserName(string username);
    }
}
