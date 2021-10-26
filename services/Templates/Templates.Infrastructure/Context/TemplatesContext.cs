using Templates.Domain.Entities;
using Templates.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System;

namespace Templates.Infrastructure.Context
{
    public class TemplatesContext : DbContext
    {
        public DbSet<Template> Templates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TemplateMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DB_URL"));
        }
    }
}
