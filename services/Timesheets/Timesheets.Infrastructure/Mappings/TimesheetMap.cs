using Timesheets.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Timesheets.Infrastructure.Mappings
{
    public class TimesheetMap : IEntityTypeConfiguration<Timesheet>
    {
        public void Configure(EntityTypeBuilder<Timesheet> builder)
        {
            builder.ToTable("timesheets");
            builder.HasKey(c => c.Id).HasName("id");

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(c => c.UserId)
                .HasColumnName("user_id")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(c => c.Start)
                .HasColumnName("start")
                .HasColumnType("timestamp with timezone")
                .IsRequired();

            builder.Property(c => c.End)
                .HasColumnName("end")
                .HasColumnType("timestamp with timezone")
                .IsRequired();
        }
    }
}
