using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parque.Domain.Entites;

namespace Parque.Persistence.Configuration
{
    public class AlianceConfig : IEntityTypeConfiguration<Aliance>
    {
        public void Configure(EntityTypeBuilder<Aliance> builder)
        {
            builder.ToTable("Aliances");
            builder.Property(p => p.Name).HasMaxLength(100);

        }
    }
}
