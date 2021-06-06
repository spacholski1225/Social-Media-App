using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IIdentityService
    {
        public Task<AuthenticationResult> RegisterAsync(string email, string password);
        public Task<AuthenticationResult> LoginAsync(string email, string password);
        public Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}
