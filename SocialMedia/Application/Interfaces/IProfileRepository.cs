using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProfileRepository
    {
        public Task<ProfileDto> FindFriendIdByUserIdAsync(string username);
        public Task<ProfileDto> GetUserProfileByIdAsync(string id);
    }
}
