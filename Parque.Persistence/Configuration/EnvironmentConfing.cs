using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Parque.Persistence.Configuration
{
    public class EnvironmentConfig : IEntityTypeConfiguration<Domain.Entites.Environment>
    {
        public void Configure(EntityTypeBuilder<Domain.Entites.Environment> builder)
        {
            builder.ToTable("Environment");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Description).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(250).IsRequired();
            builder.Property(p => p.DocumentRoute).HasMaxLength(300).IsRequired();
            builder.Property(p => p.CreatedBy).HasMaxLength(30);
            builder.Property(p => p.LastModifiedBy).HasMaxLength(30);

        }
    }
}
