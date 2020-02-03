using System.Threading.Tasks;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Dtos.InputModels.Auth;

namespace ELearningApp.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<EmailResponse> Register(RegisterInputModel registerModel);
        Task<JsonWebToken> Login(LoginInputModel loginModel);
        Task VerifyEmail(string userId, string emailToken);
    }
}