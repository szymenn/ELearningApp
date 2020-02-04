using System.Threading.Tasks;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Dtos.InputModels.Auth;
using ELearningApp.Core.Interfaces.Repositories.Auth;
using ELearningApp.Core.Interfaces.Services.Auth;
using Microsoft.AspNetCore.Identity;

namespace ELearningApp.Infrastructure.Repositories.Auth
{
    public class UserRepository : IUserRepository
    {
        private UserManager<IdentityUser> _userManager;
        private ITokenService _tokenService;
        private IEmailService _emailService;
        private SignInManager<IdentityUser> _signInManager;

        public UserRepository(
            UserManager<IdentityUser> userManager,
            ITokenService tokenService,
            IEmailService emailService,
            SignInManager<IdentityUser> signInManager
        )
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _emailService = emailService;
            _signInManager = signInManager;
        }
        
        
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