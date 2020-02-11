using System;
using System.Security.Cryptography;
using ELearningApp.Core.Entities;
using ELearningApp.Core.Entities.Auth;
using ELearningApp.Core.Interfaces.Repositories.Auth;
using ELearningApp.Core.Interfaces.Services.Auth;

namespace ELearningApp.Core.Services.Auth
{
    public class RefreshTokenHandler : IRefreshTokenHandler
    {
        private readonly ITokenRepository _tokenRepository;

        public RefreshTokenHandler(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        
        public string CreateRefreshToken(string userName, Guid userId)
        {
            var refreshToken = CreateRefreshToken();
            SaveRefreshToken(refreshToken, userName, userId);
            return refreshToken;
        }

        public string UpdateRefreshToken(string token)
        {
            var updateToken = CreateRefreshToken();
            return _tokenRepository.UpdateRefreshToken(token, updateToken);
        }
        
        private void SaveRefreshToken(string token, string userName, Guid userId)
        {
            _tokenRepository.SaveRefreshToken(new RefreshToken
            {
                Token = token,
                UserName = userName,
                UserId = userId
            });
        }

        private string CreateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var randomGenerator = RandomNumberGenerator.Create())
            {
                randomGenerator.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}