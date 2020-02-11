using System.Security.Claims;
using System.Threading.Tasks;
using ELearningApp.Core.Auth.Requirements;
using ELearningApp.Core.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace ELearningApp.Core.Auth.Handlers
{
    public class TeacherHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Issuer == Constants.ApiUrl))
            {
                return Task.CompletedTask;
            }

            if (requirement.Role == RoleEnum.Teacher)
            {
                context.Succeed(requirement);
            }
            
            return Task.CompletedTask;
        }
    }
}