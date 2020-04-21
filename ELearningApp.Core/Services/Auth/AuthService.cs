using System.Threading.Tasks;
using AutoMapper;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Dtos.InputModels.Auth;
using ELearningApp.Core.Entities.Auth;
using ELearningApp.Core.Interfaces.Repositories;
using ELearningApp.Core.Interfaces.Repositories.Auth;
using ELearningApp.Core.Interfaces.Services.Auth;
using Microsoft.AspNetCore.Identity;

namespace ELearningApp.Core.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository, ITokenService tokenService, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        
        public async Task<EmailResponse> Register(User user, string password)
        {
            return await _userRepository.Register(user, password);
        }

        public async Task<JsonWebToken> Login(LoginInputModel loginModel, string password)
        {
            return await _userRepository.Login(_mapper.Map<User>(loginModel), password);
        }

        public async Task<EmailResponse> Register(RegisterInputModel registerModel, string password)
        {
            return await _userRepository.Register(_mapper.Map<User>(registerModel), password);
        }

        public async Task VerifyEmail(string userId, string emailToken)
        {
            await _userRepository.VerifyEmail(userId, emailToken);
        }

        public JsonWebToken RefreshAccessToken(string token)
        {
            return _tokenService.RefreshAccessToken(token);
        }

        public void RevokeRefreshToken(string token)
        {
            _tokenService.RevokeRefreshToken(token);
        }
    }
}