using System;

namespace ELearningApp.Core.Interfaces.Services.Auth
{
    public interface IRefreshTokenService
    {
        string CreateRefreshToken(string userName, Guid userId);
        string UpdateRefreshToken(string token);
    }
}