using System.Threading.Tasks;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Dtos.InputModels.Auth;

namespace ELearningApp.Core.Interfaces.Services.Auth
{
    public interface IAuthService
    {
        Task<JsonWebToken> Login(LoginInputModel loginModel);
        Task<EmailResponse> Register(RegisterInputModel registerModel);
        Task VerifyEmail(string userId, string emailToken);
        JsonWebToken RefreshAccessToken(string token);
        void RevokeRefreshToken(string token);
    }
}