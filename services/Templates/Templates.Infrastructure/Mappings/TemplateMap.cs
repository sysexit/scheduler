using Templates.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Templates.Infrastructure.Mappings
{
    public class TemplateMap : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.ToTable("templates");
            builder.HasKey(c => c.Id).HasName("id");

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(c => c.Start)
                .HasColumnName("start")
                .HasColumnType("character(5)")
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(c => c.End)
                .HasColumnName("end")
                .HasColumnType("character(5)")
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(c => c.Position)
                .HasColumnName("position_id")
                .HasColumnType("integer")
                .IsRequired();
        }
    }
}
