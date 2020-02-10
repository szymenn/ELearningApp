using System.Threading.Tasks;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Dtos.InputModels.Auth;
using Microsoft.AspNetCore.Identity;

namespace ELearningApp.Core.Interfaces.Repositories.Auth
{
    public interface IUserRepository
    {
        Task<EmailResponse> Register(IdentityUser user, string password);
        Task<JsonWebToken> Login(IdentityUser user, string password);
        Task VerifyEmail(string userId, string emailToken);
    }
}