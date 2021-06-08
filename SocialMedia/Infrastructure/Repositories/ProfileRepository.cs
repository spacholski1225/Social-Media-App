using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Config;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DatabaseConfig
        public ProfileRepository()
        {
                
        }
        public Task<ProfileDto> GetUserProfile(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
