using Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Infrastructure.Mappings
{
    public class LoginMap : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("logins");
            builder.HasKey(c => c.Email).HasName("email");
            //builder.Property(c => c.Id)
            //    .HasColumnName("Id");

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.PasswordHash)
                .HasColumnName("password")
                .HasColumnType("varchar(60)")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(c => c.Group)
                .HasColumnName("group")
                .HasColumnType("integer")
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(c => c.Enabled)
                .HasColumnName("enabled")
                .HasColumnType("boolean")
                .HasDefaultValue(true)
                .IsRequired();
        }
    }
}
