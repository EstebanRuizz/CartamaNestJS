using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parque.Domain.Entites;

namespace Parque.Persistence.Configuration
{
    public class RolConfig : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Name).HasMaxLength(60).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(300).IsRequired();
            builder.Property(p => p.IsActive).HasMaxLength(30).IsRequired();
            builder.Property(p => p.CreatedBy).HasMaxLength(30);
            builder.Property(p => p.LastModifiedBy).HasMaxLength(30);

        }
    }
}