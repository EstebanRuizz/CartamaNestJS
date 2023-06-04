using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parque.Domain.Entites;

namespace Parque.Persistence.Configuration
{
    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Description).HasMaxLength(500).IsRequired();
            builder.HasOne(p => p.IdUserNavigation).WithMany(p => p.Reservations).HasForeignKey(p => p.IdUser).HasPrincipalKey(p => p.Id);
            builder.HasOne(p => p.IdEnvironmentNavigation).WithMany(p => p.Reservations).HasForeignKey(p => p.IdEnviroment).HasPrincipalKey(p => p.Id);
            builder.Property(p => p.CreatedBy).HasMaxLength(30);
            builder.Property(p => p.LastModifiedBy).HasMaxLength(30);
        }
    }
}