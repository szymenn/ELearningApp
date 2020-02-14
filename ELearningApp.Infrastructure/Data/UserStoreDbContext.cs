using ELearningApp.Core.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ELearningApp.Infrastructure.Data
{
    public class UserStoreDbContext : IdentityDbContext<IdentityUser>
    {
        public UserStoreDbContext(DbContextOptions<UserStoreDbContext> options)
            : base(options)
        {
        }

        public new DbSet<User> Users { get; set; }
    }
}