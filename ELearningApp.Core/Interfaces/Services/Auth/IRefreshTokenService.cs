using System;

namespace ELearningApp.Core.Interfaces.Services.Auth
{
    public interface IRefreshTokenHandler
    {
        string CreateRefreshToken(string userName, Guid userId);
        string UpdateRefreshToken(string token);
    }
}