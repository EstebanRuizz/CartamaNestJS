using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parque.Domain.Entites;

namespace Parque.Persistence.Configuration
{
    public class NewsPaperConfig : IEntityTypeConfiguration<NewsPaper>
    {
        public void Configure(EntityTypeBuilder<NewsPaper> builder)
        {
            builder.ToTable("NewsPapers");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(300);
            builder.Property(p => p.DocumentRoute).HasMaxLength(300);
            builder.HasOne(p => p.IdPublishingHouseNavigation).WithMany(p => p.NewsPapers).HasForeignKey(p => p.IdPublishingHouse).HasPrincipalKey(p => p.Id);
            builder.Property(p => p.CreatedBy).HasMaxLength(30);
            builder.Property(p => p.LastModifiedBy).HasMaxLength(30);
        }
    }
}
