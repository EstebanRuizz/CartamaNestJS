using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parque.Domain.Entites;

namespace Parque.Persistence.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(e => e.Id);
            builder.Property(p => p.IdentityDocument).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(150);
            builder.Property(p => p.FirstName).HasMaxLength(100);
            builder.Property(p => p.LastName).HasMaxLength(100);
            builder.Property(p => p.Phone).HasMaxLength(15);
            builder.Property(p => p.Password).HasMaxLength(30);
            builder.Property(p => p.ProfilePictureRoute).HasMaxLength(300);
            builder.HasOne(p => p.IdTypeDocumentNavigation).WithMany(p => p.Users).HasForeignKey(p => p.IdTypeDocument).HasPrincipalKey(p => p.Id);
            builder.HasOne(p => p.IdRolNavigation).WithMany(p => p.Users).HasForeignKey(p => p.IdRol).HasPrincipalKey(p => p.Id);
            builder.Property(p => p.CreatedBy).HasMaxLength(30);
            builder.Property(p => p.LastModifiedBy).HasMaxLength(30);
        }
    }
}