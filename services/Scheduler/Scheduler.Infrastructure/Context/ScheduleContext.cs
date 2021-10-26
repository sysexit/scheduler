using Scheduler.Domain.Entities;
using Scheduler.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System;

namespace Scheduler.Infrastructure.Context
{
    public class ScheduleContext : DbContext
    {
        public DbSet<Schedule> Schedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ScheduleMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DB_URL"), o => o.UseNodaTime());
        }
    }
}
