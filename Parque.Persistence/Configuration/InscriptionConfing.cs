using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parque.Domain.Entites;

namespace Parque.Persistence.Configuration
{
    public class InscriptionConfig : IEntityTypeConfiguration<Inscription>
    {
        public void Configure(EntityTypeBuilder<Inscription> builder)
        {
            builder.ToTable("Inscriptions");
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.IdUserNavigation).WithMany(p => p.Inscriptions).HasForeignKey(p => p.IdUser).HasPrincipalKey(p => p.Id);
            builder.HasOne(p => p.IdPublicationNavigation).WithMany(p => p.Inscriptions).HasForeignKey(p => p.IdPublication).HasPrincipalKey(p => p.Id);
            builder.Property(p => p.UserDocumentRoute).HasMaxLength(500);
            builder.Property(p => p.CreatedBy).HasMaxLength(30);
            builder.Property(p => p.LastModifiedBy).HasMaxLength(30);
        }
    }
}
