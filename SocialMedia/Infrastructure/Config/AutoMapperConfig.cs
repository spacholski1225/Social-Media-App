using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Config
{
    public class AutoMapperConfig
    {
        private IMapper _mapper;
        public AutoMapperConfig()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IdentityUser, IdentityUser>();
                cfg.CreateMap<IdentityUser, ProfileDto>();
            }).CreateMapper();
        }
        public IdentityUser MapToIdentityUser(IdentityUser user)
        {
            return _mapper.Map<IdentityUser>(user);
        }
        public ProfileDto MapIdentityUserToProfileDto(IdentityUser user)
        {
            return _mapper.Map<ProfileDto>(user);
        }
    }
}
