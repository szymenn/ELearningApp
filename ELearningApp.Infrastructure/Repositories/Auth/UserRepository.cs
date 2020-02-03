using System.Threading.Tasks;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Dtos.InputModels.Auth;
using ELearningApp.Core.Interfaces.Repositories.Auth;

namespace ELearningApp.Infrastructure.Repositories.Auth
{
    public class UserRepository : IUserRepository
    {
        public Task<EmailResponse> Register(RegisterInputModel registerModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<JsonWebToken> Login(LoginInputModel loginModel)
        {
            throw new System.NotImplementedException();
        }

        public Task VerifyEmail(string userId, string emailToken)
        {
            throw new System.NotImplementedException();
        }
    }
}