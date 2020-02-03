using System;
using ELearningApp.Core.Dtos.ApiModels.Auth;

namespace ELearningApp.Core.Interfaces.Services.Auth
{
    public interface ITokenService
    {
        JsonWebToken CreateAccessToken(string userName, Guid userId);
        JsonWebToken RefreshAccessToken(string token);
        void RevokeRefreshToken(string token);
    }
}