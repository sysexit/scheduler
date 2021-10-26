using Positions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Positions.Infrastructure.Mappings
{
    public class PositionMap : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("positions");
            builder.HasKey(c => c.Id).HasName("id");

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(c => c.Title)
                .HasColumnName("title")
                .HasColumnType("character(10)")
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
