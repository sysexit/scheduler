using Timesheets.Domain.Entities;
using Timesheets.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System;

namespace Timesheets.Infrastructure.Context
{
    public class TimesheetsContext : DbContext
    {
        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<Schedule> Schedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TimesheetMap());
            modelBuilder.ApplyConfiguration(new ScheduleMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DB_URL"));
        }
    }
}
