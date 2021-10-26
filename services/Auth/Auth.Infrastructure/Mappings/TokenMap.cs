using Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Infrastructure.Mappings
{
    public class TokenMap : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.ToTable("tokens");
            builder.HasKey(c => c.Email).HasName("email");

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(c => c.AccessToken)
                .HasColumnName("token")
                .HasColumnType("varchar(32)");
        }
    }
}
