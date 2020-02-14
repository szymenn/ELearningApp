using System.Threading.Tasks;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Dtos.InputModels.Auth;
using ELearningApp.Core.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace ELearningApp.Core.Interfaces.Repositories.Auth
{
    public interface IUserRepository
    {
        Task<EmailResponse> Register(User user, string password);
        Task<JsonWebToken> Login(User user, string password);
        Task VerifyEmail(string userId, string emailToken);
    }
}