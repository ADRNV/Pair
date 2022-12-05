using Microsoft.EntityFrameworkCore;
using Pair.Infrastructure.EF.Security.Entities;
using Pair.Infrastructure.EF.Security.Entities.Configurations;

namespace Pair.Infrastructure.EF.Security
{
    public class AuthContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AuthContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());   
        }
    }
}
