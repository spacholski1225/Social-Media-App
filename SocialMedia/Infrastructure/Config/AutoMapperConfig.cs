using AutoMapper;
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
            }).CreateMapper();
        }
        public IdentityUser MapToIdentityUser(IdentityUser user)
        {
            return _mapper.Map<IdentityUser>(user);
        }
    }
}
