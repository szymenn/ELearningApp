using System.Collections.Generic;
using System.Security.Claims;

namespace ELearningApp.Core.Interfaces.Services.Auth
{
    public interface IJwtHandler
    {
        string CreateAccessToken(IEnumerable<Claim> claims);
    }
}