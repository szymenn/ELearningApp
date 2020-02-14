using System;
using ELearningApp.Core.Helpers;

namespace ELearningApp.Core.Interfaces.Services.Auth
{
    public interface IRefreshTokenService
    {
        string CreateRefreshToken(string userName, Guid userId, RoleEnum role);
        string UpdateRefreshToken(string token);
    }
}