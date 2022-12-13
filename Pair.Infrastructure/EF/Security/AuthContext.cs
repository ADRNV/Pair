using Microsoft.EntityFrameworkCore;
using Pair.Infrastructure.EF.Security.Entities;
using Pair.Infrastructure.EF.Security.Entities.Configurations;

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
            _connectionString = connectionString;
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    Login = "root",
                    Password = "toor",
                    Permissions = true
                },
                new User
                {
                    Id = 2,
                    Login = "User",
                    Password = "qwerty",
                    Permissions = false
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
