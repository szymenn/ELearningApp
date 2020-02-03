using System.Collections.Generic;
using System.Security.Claims;
using ELearningApp.Core.Entities;
using ELearningApp.Core.Entities.Auth;

namespace ELearningApp.Core.Interfaces.Repositories.Auth
{
    public interface ITokenRepository
    {
        void SaveRefreshToken(RefreshToken refreshToken);
        void RemoveRefreshToken(string token);
        bool CanRefresh(string token);
        void RevokeRefreshToken(string token);
        string UpdateRefreshToken(string token, string updateToken);
        IEnumerable<Claim> GetUserClaims(string token);
    }
}