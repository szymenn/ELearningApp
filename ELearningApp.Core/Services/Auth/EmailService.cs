using System.Threading.Tasks;
using System.Web;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Exceptions;
using ELearningApp.Core.Helpers;
using ELearningApp.Core.Interfaces.Services.Auth;
using ELearningApp.Core.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ELearningApp.Core.Services.Auth
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<EmailVerificationSettings> _emailSettings;

        public EmailService(IOptions<EmailVerificationSettings> emailSettings)
        {
            _emailSettings = emailSettings;
        }
        
        public async Task<EmailResponse> SendEmailAsync(IdentityUser user, string token)
        {
            var client = new SendGridClient(_emailSettings.Value.ApiKey);
            var from = new EmailAddress(_emailSettings.Value.FromEmail, _emailSettings.Value.FromName);
            var to = new EmailAddress(user.Email, user.Email);
            var content = $"<a href={Constants.ApiUrl}/user/email/verify" +
                          $"?userId={HttpUtility.UrlEncode(user?.Id)}" +
                          $"&confirmationToken={HttpUtility.UrlEncode(token)}>Verify</a>";
            var msg = MailHelper.CreateSingleEmail(
                from, 
                to, 
                _emailSettings.Value.Subject, 
                null,
                content);
            
            var response = await client.SendEmailAsync(msg);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                return new EmailResponse();

            }
            
            throw new EmailServiceException(Constants.EmailServiceException);
        }
    }
}