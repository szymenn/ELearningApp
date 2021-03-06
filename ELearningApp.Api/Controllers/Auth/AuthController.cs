using System;
using System.Threading.Tasks;
using AutoMapper;
using ELearningApp.Core.Dtos.InputModels.Auth;
using ELearningApp.Core.Entities.Auth;
using ELearningApp.Core.Interfaces.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApp.Api.Controllers.Auth
{
    [ApiController, Route("auth"), Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("users/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginInputModel loginModel)
        {
            return Ok(new
            {
                Tokens = await _authService.Login
                    (_mapper.Map<User>(loginModel), loginModel.Password)
            });
        }

        [HttpPost("users/register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterInputModel registerModel)
        {
            return Ok(new
            {
                Response = await _authService.Register
                    (_mapper.Map<User>(registerModel), registerModel.Password)
            });
        }

        [HttpPost("tokens/refresh")]
        [AllowAnonymous]
        public IActionResult RefreshAccessToken(string token)
        {
            return Ok(new
            {
                Tokens = _authService.RefreshAccessToken(token)
            });
        }

        [HttpPost("tokens/revoke")]
        public IActionResult RevokeAccessToken(string token)
        {
            _authService.RevokeRefreshToken(token);
            return NoContent();
        }

        [HttpGet("email/verify")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyEmail(string userId, string confirmationToken)
        {
            await _authService.VerifyEmail(userId, confirmationToken);
            return Redirect("https://google.com");
        }
        
    }
}