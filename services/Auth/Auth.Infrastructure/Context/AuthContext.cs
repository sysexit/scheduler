using Auth.Domain.Entities;
using Auth.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System;

namespace Auth.Infrastructure.Context
{
    public class AuthContext : DbContext
    {
        public DbSet<Login> Login { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Token> Token { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LoginMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TokenMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DB_URL"));
        }
    }
}
