using Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Users.Infrastructure.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(c => c.Id).HasName("id");

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(c => c.First)
                .HasColumnName("first")
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(c => c.Last)
                .HasColumnName("last")
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(c => c.Positions)
                .HasColumnName("positions")
                .HasColumnType("integer[]");

            builder.Property(c => c.Display)
                .HasColumnName("display")
                .HasColumnType("varchar(10)");
        }
    }
}
