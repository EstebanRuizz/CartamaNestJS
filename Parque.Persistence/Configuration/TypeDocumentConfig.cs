using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parque.Domain.Entites;

namespace Parque.Persistence.Configuration
{
    public class TypeDocumentConfig : IEntityTypeConfiguration<TypeDocument>
    {
        public void Configure(EntityTypeBuilder<TypeDocument> builder)
        {
            builder.ToTable("TypeDocuments");
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            
        }
    }
}