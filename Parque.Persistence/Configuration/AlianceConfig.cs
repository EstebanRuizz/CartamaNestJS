using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parque.Domain.Entites;

namespace Parque.Persistence.Configuration
{
    public class AlianceConfig : IEntityTypeConfiguration<Aliance>
    {
        public void Configure(EntityTypeBuilder<Aliance> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Aliances");
            builder.Property(p => p.Name).HasMaxLength(250);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.HasOne(p => p.IdTypeAliancesNavigation).WithMany(p => p.Aliances)
                .HasForeignKey(e => e.IdTypeAliance)
                .HasPrincipalKey(p => p.Id);

            builder.Property(p => p.CreatedBy).HasMaxLength(30);
            builder.Property(p => p.LastModifiedBy).HasMaxLength(30);
        }
    }
}
