using System.Threading.Tasks;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Dtos.InputModels.Auth;
using ELearningApp.Core.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace ELearningApp.Core.Interfaces.Services.Auth
{
    public interface IAuthService
    {
        Task<JsonWebToken> Login(User user, string password);
        Task<EmailResponse> Register(User user, string password);
        Task VerifyEmail(string userId, string emailToken);
        JsonWebToken RefreshAccessToken(string token);
        void RevokeRefreshToken(string token);
    }
}