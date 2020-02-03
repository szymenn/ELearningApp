using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using ELearningApp.Core.Entities;
using ELearningApp.Core.Entities.Auth;
using ELearningApp.Core.Exceptions;
using ELearningApp.Core.Interfaces.Repositories.Auth;
using ELearningApp.Infrastructure.Data;
using Microsoft.IdentityModel.JsonWebTokens;

namespace ELearningApp.Infrastructure.Repositories.Auth
{
    public class TokenRepository : ITokenRepository
    {
        private readonly TokenStoreDbContext _context;

        public TokenRepository(TokenStoreDbContext context)
        {
            _context = context;
        } 
        
        public void SaveRefreshToken(RefreshToken refreshToken)
        {
            if (_context.Tokens.Any(p => p.Token == refreshToken.Token))
            {
                throw new ResourceAlreadyExistsException();
            }

            _context.Add(refreshToken);
            _context.SaveChanges();
        }

        public void RemoveRefreshToken(string token)
        {
            var refreshToken = _context.Tokens.FirstOrDefault(p => p.Token == token);
            if (refreshToken == null)
            {
                throw new ResourceNotFoundException();
            }

            _context.Remove(refreshToken);
            _context.SaveChanges();
        }

        public bool CanRefresh(string token)
        {
            var refreshToken = _context.Tokens.FirstOrDefault(p => p.Token == token);
            if (refreshToken == null)
            {
                return false;
            }

            return !refreshToken.Revoked;
        }

        public void RevokeRefreshToken(string token)
        {
            var refreshToken = _context.Tokens.FirstOrDefault(p => p.Token == token);
            if (refreshToken == null)
            {
                throw new ResourceNotFoundException();
            }

            refreshToken.Revoked = true;
            _context.SaveChanges();
        }

        public string UpdateRefreshToken(string token, string updateToken)
        {
            var refreshToken = _context.Tokens.FirstOrDefault(p => p.Token == token);
            if (refreshToken == null)
            {
                throw new ResourceNotFoundException();
            }

            refreshToken.Token = updateToken;
            _context.SaveChanges();
            return updateToken;
        }

        public IEnumerable<Claim> GetUserClaims(string token)
        {
            var refreshToken = _context.Tokens.FirstOrDefault(p => p.Token == token);
            if (refreshToken == null)
            {
                throw new ResourceNotFoundException();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, refreshToken.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, refreshToken.UserId.ToString())
            };
            return claims;
        }
    }
}