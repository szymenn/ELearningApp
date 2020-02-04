using System.Threading.Tasks;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using Microsoft.AspNetCore.Identity;

namespace ELearningApp.Core.Interfaces.Services.Auth
{
    public interface IEmailService
    {
        Task<EmailResponse> SendEmailAsync(IdentityUser user, string token);
    }
}