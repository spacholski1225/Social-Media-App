using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DatabaseConfig _context;
        private readonly AutoMapperConfig _mapper;
        public ProfileRepository(DatabaseConfig context, AutoMapperConfig mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProfileDto> GetUserProfileAsync(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if(user == null)
            {
                return null;
            }
            var profileDto = _mapper.MapIdentityUserToProfileDto(user);
            return profileDto;
        }
    }
}
