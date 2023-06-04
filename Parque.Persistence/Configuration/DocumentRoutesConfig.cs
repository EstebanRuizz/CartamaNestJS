using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parque.Domain.Entites;

namespace Parque.Persistence.Configuration
{
    public class DocumentRoutesConfig : IEntityTypeConfiguration<DocumentRoutes>
    {
        public void Configure(EntityTypeBuilder<DocumentRoutes> builder)
        {
            builder.ToTable("DocumentRoutes");
            builder.HasKey(e => e.Id);
            builder.Property(p => p.BaseRoute).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(255).IsRequired();
            builder.Property(p => p.CreatedBy).HasMaxLength(30);
            builder.Property(p => p.LastModifiedBy).HasMaxLength(30);
        }
    }
}