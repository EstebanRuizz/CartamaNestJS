using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parque.Domain.Entites;

namespace Parque.Persistence.Configuration
{
    public class PublicationConfig : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.ToTable("Publication");
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Title).HasMaxLength(255).IsRequired();
            builder.Property(p => p.HasForm).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(255).IsRequired();
            builder.Property(p => p.ImageRoute).HasMaxLength(300).IsRequired();
            builder.HasOne(p => p.IdTypePublicationNavigation).WithMany(p => p.Publications).HasForeignKey(p => p.idTypeOfPublication).HasPrincipalKey(p => p.Id);
            builder.Property(p => p.CreatedBy).HasMaxLength(30);
            builder.Property(p => p.LastModifiedBy).HasMaxLength(30);
        }
    }
}
/*
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Aliances");
            builder.Property(p => p.Name).HasMaxLength(250);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.HasOne(p => p.IdTypeAliancesNavigation).WithMany(p => p.Aliances)
                .HasForeignKey(e => e.IdTypeAliance)
                .HasPrincipalKey(p => p.Id);
        }
 */