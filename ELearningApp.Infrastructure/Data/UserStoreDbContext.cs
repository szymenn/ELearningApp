using ELearningApp.Core.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ELearningApp.Infrastructure.Data
{
    public class UserStoreDbContext : IdentityDbContext<AppUser>
    {
        
    }
}