using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parque.Domain.Entites;

namespace Parque.Persistence.Configuration
{
    public class TypePublicationConfig : IEntityTypeConfiguration<TypePublication>
    {
        public void Configure(EntityTypeBuilder<TypePublication> builder)
        {
            builder.ToTable("TypePublications");
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(300);
            builder.Property(p => p.CreatedBy).HasMaxLength(30);
            builder.Property(p => p.LastModifiedBy).HasMaxLength(30);
        }
    }
}