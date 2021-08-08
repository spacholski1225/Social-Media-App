using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AutoMapperConfig _mapper;
        private readonly IUserRepository _userRepsitory;
        public ProfileRepository(AutoMapperConfig mapper, IUserRepository userRepsitory)
        {
            _mapper = mapper;
            _userRepsitory = userRepsitory;
        }

        public async Task<ProfileDto> GetUserProfileByIdAsync(string id)
        {
            var user = await _userRepsitory.GetUserByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            var profileDto = _mapper.MapIdentityUserToProfileDto(user);
            return profileDto;
        }

        public async Task<ProfileDto> GetUserProfileByUsernameAsync(string userName)
        {
            var user = await _userRepsitory.GetUserByUserNameAsync(userName);
            if (user == null)
            {
                return null;
            }
            var profileDto = _mapper.MapIdentityUserToProfileDto(user);
            return profileDto;
        }
    }
}
