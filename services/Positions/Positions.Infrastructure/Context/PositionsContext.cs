using Positions.Domain.Entities;
using Positions.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System;

namespace Positions.Infrastructure.Context
{
    public class PositionsContext : DbContext
    {
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PositionMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DB_URL"));
        }
    }
}
