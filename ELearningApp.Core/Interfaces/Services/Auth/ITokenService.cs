using System;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Helpers;

namespace ELearningApp.Core.Interfaces.Services.Auth
{
    public interface ITokenService
    {
        JsonWebToken CreateAccessToken(string userName, Guid userId, RoleEnum role);
        JsonWebToken RefreshAccessToken(string token);
        void RevokeRefreshToken(string token);
    }
}