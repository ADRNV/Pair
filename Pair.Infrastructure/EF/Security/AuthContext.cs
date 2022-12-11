using Microsoft.EntityFrameworkCore;
using Pair.Infrastructure.EF.Security.Entities;
using Pair.Infrastructure.EF.Security.Entities.Configurations;
using System.Data.Common;

namespace Pair.Infrastructure.EF.Security
{
    public class AuthContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        private readonly string _connectionString;

        public AuthContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public AuthContext(string connectionString)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());   
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
