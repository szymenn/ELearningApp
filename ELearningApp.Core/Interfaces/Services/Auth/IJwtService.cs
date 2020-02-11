using System.Collections.Generic;
using System.Security.Claims;

namespace ELearningApp.Core.Interfaces.Services.Auth
{
    public interface IJwtService
    {
        string CreateAccessToken(IEnumerable<Claim> claims);
    }
}