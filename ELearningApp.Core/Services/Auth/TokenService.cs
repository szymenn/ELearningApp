using System;
using System.Security.Claims;
using ELearningApp.Core.Interfaces.Repositories.Auth;
using ELearningApp.Core.Interfaces.Services.Auth;
using Microsoft.IdentityModel.JsonWebTokens;
using JsonWebToken = ELearningApp.Core.Dtos.ApiModels.Auth.JsonWebToken;

namespace ELearningApp.Core.Services.Auth
{
    public class TokenService : ITokenService
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IRefreshTokenHandler _refreshTokenHandler;
        private readonly ITokenRepository _tokenRepository;

        public TokenService(
            IJwtHandler jwtHandler,
            IRefreshTokenHandler refreshTokenHandler,
            ITokenRepository tokenRepository
        )
        {
            _jwtHandler = jwtHandler;
            _refreshTokenHandler = refreshTokenHandler;
            _tokenRepository = tokenRepository;
        }
        
        public JsonWebToken CreateAccessToken(string userName, Guid userId)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };

            return new JsonWebToken
            {
                AccessToken = _jwtHandler.CreateAccessToken(claims),
                RefreshToken = _refreshTokenHandler.CreateRefreshToken(userName, userId),
            };
        }

        public JsonWebToken RefreshAccessToken(string token)
        {
            var userClaims = _tokenRepository.GetUserClaims(token);

            var refreshToken = _refreshTokenHandler.UpdateRefreshToken(token);
            var accessToken = _jwtHandler.CreateAccessToken(userClaims);
            return new JsonWebToken
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
        }

        public void RevokeRefreshToken(string token)
        {
            _tokenRepository.RevokeRefreshToken(token);
        }
    }
}