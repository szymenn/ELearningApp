using System;
using System.Security.Cryptography;
using ELearningApp.Core.Entities;
using ELearningApp.Core.Entities.Auth;
using ELearningApp.Core.Helpers;
using ELearningApp.Core.Interfaces.Repositories.Auth;
using ELearningApp.Core.Interfaces.Services.Auth;

namespace ELearningApp.Core.Services.Auth
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly ITokenRepository _tokenRepository;

        public RefreshTokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        
        public string CreateRefreshToken(string userName, Guid userId, RoleEnum role)
        {
            var refreshToken = CreateRefreshToken();
            _tokenRepository.SaveRefreshToken(new RefreshToken
            {
                Token = refreshToken,
                UserName = userName,
                Role = role,
                UserId = userId
            });
            
            return refreshToken;
        }

        public string UpdateRefreshToken(string token)
        {
            var updateToken = CreateRefreshToken();
            return _tokenRepository.UpdateRefreshToken(token, updateToken);
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