using System;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Interfaces.Services.Auth;

namespace ELearningApp.Core.Services.Auth
{
    public class TokenService : ITokenService
    {
        public JsonWebToken CreateAccessToken(string userName, Guid userId)
        {
            throw new NotImplementedException();
        }

        public JsonWebToken RefreshAccessToken(string token)
        {
            throw new NotImplementedException();
        }

        public void RevokeAccessToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}