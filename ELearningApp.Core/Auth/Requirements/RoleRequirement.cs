using ELearningApp.Core.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace ELearningApp.Core.Auth.Requirements
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public RoleEnum Role { get; }

        public RoleRequirement(RoleEnum role)
        {
            Role = role;
        }
    }
}