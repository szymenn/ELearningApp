using ELearningApp.Core.Entities;
using ELearningApp.Core.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace ELearningApp.Infrastructure.Data
{
    public class TokenStoreDbContext : DbContext
    {
        public TokenStoreDbContext(DbContextOptions<TokenStoreDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<RefreshToken> Tokens { get; set; }
    }
}