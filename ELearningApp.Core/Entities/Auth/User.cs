using ELearningApp.Core.Helpers;
using Microsoft.AspNetCore.Identity;

namespace ELearningApp.Core.Entities.Auth
{
    public class User : IdentityUser
    {
        public RoleEnum Role { get; set; }
    }
}