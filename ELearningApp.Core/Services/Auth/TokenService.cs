using System;
using System.Security.Claims;
using ELearningApp.Core.Helpers;
using ELearningApp.Core.Interfaces.Repositories.Auth;
using ELearningApp.Core.Interfaces.Services.Auth;
using Microsoft.IdentityModel.JsonWebTokens;
using JsonWebToken = ELearningApp.Core.Dtos.ApiModels.Auth.JsonWebToken;

namespace ELearningApp.Core.Services.Auth
{
    public class TokenService : ITokenService
    {
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly ITokenRepository _tokenRepository;

        public TokenService(
            IJwtService jwtService,
            IRefreshTokenService refreshTokenService,
            ITokenRepository tokenRepository
        )
        {
            _jwtService = jwtService;
            _refreshTokenService = refreshTokenService;
            _tokenRepository = tokenRepository;
        }
        
        public JsonWebToken CreateAccessToken(string userName, Guid userId, RoleEnum role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Role, role.ToString()), 
            };

            return new JsonWebToken
            {
                AccessToken = _jwtService.CreateAccessToken(claims),
                RefreshToken = _refreshTokenService.CreateRefreshToken(userName, userId, role),
            };
        }

        public JsonWebToken RefreshAccessToken(string token)
        {
            var userClaims = _tokenRepository.GetUserClaims(token);

            var refreshToken = _refreshTokenService.UpdateRefreshToken(token);
            var accessToken = _jwtService.CreateAccessToken(userClaims);
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