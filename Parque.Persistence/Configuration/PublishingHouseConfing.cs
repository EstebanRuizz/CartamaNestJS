using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parque.Domain.Entites;

namespace Parque.Persistence.Configuration
{
    public class PublishingHouseConfig : IEntityTypeConfiguration<PublishingHouse>
    {
        public void Configure(EntityTypeBuilder<PublishingHouse> builder)
        {
            builder.ToTable("PublishingHouse");
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Name).HasMaxLength(255).IsRequired();
            builder.Property(p => p.CreatedBy).HasMaxLength(30);
            builder.Property(p => p.LastModifiedBy).HasMaxLength(30);
        }
    }
}