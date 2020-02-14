using System;
using System.Linq;
using System.Threading.Tasks;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Dtos.InputModels.Auth;
using ELearningApp.Core.Entities.Auth;
using ELearningApp.Core.Exceptions;
using ELearningApp.Core.Helpers;
using ELearningApp.Core.Interfaces.Repositories.Auth;
using ELearningApp.Core.Interfaces.Services.Auth;
using Microsoft.AspNetCore.Identity;

namespace ELearningApp.Infrastructure.Repositories.Auth
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(
            UserManager<User> userManager,
            ITokenService tokenService,
            IEmailService emailService,
            SignInManager<User> signInManager
        )
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _emailService = emailService;
            _signInManager = signInManager;
        }
        
        
        public async Task<EmailResponse> Register(User user, string password)
        {
            if (_userManager.Users.Any(u => u.UserName == user.UserName)) 
            {
                throw new ResourceAlreadyExistsException(Constants.UserAlreadyExists);
            }
            
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                throw new RegistrationException(Constants.RegistrationError);
            }
            
            var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return await _emailService.SendEmailAsync(user, confirmationToken);
        }

        public async Task<JsonWebToken> Login(User user, string password)
        {
            var loginUser = _userManager.Users.FirstOrDefault(u => u.UserName == user.UserName && user.Role == u.Role);            
            if (loginUser == null)
            {
                throw new ResourceNotFoundException(Constants.UserNotFound);
            }
            
            var result = await _signInManager.PasswordSignInAsync
                (loginUser, password, false, false);
            if (!result.Succeeded)
            {
                throw new LoginException(Constants.LoginFailed);
            }

            return _tokenService.CreateAccessToken(user.UserName, Guid.Parse(user.Id), user.Role);
        }

        public async Task VerifyEmail(string userId, string emailToken)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ResourceNotFoundException(Constants.UserNotFound);
            }

            var result = await _userManager.ConfirmEmailAsync(user, emailToken);
            if (!result.Succeeded)
            {
                throw new EmailVerificationException(Constants.EmailVerificationException);
            }
        }
    }
}