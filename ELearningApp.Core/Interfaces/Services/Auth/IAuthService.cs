using System.Threading.Tasks;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Dtos.InputModels.Auth;
using ELearningApp.Core.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace ELearningApp.Core.Interfaces.Services.Auth
{
    public interface IAuthService
    {
        Task<JsonWebToken> Login(LoginInputModel loginModel, string password);
        Task<EmailResponse> Register(RegisterInputModel registerModel, string password);
        Task VerifyEmail(string userId, string emailToken);
        JsonWebToken RefreshAccessToken(string token);
        void RevokeRefreshToken(string token);
    }
}