using Microsoft.EntityFrameworkCore;
using Parque.Application.Interfaces;
using Parque.Domain.BaseEntity;
using Parque.Domain.Entites;

namespace Parque.Persistence.DBcontext
{
    public class ParqueDbContext : DbContext
    {
        public ParqueDbContext() { }

        private readonly IDateTimeService _dateTimeService;
        public ParqueDbContext(DbContextOptions<ParqueDbContext> options, IDateTimeService dateTimeService) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTimeService = dateTimeService;
        }

        public virtual DbSet<Aliance> Aliances { get; set; }
        public virtual DbSet<DocumentRoutes> DocumentRoutes { get; set; }
        public virtual DbSet<Parque.Domain.Entites.Environment> Environments { get; set; }
        public virtual DbSet<Inscription> Inscriptions { get; set; }
        public virtual DbSet<NewsPaper> NewsPapers { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Publishing> Publishings { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<TypeAliance> TypeAliances { get; set; }
        public virtual DbSet<TypeDocument> TypeDocuments { get; set; }
        public virtual DbSet<TypePublication> TypePublications { get; set; }
        public virtual DbSet<User> Users { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTimeService.NowUtc;
                        entry.Entity.CreatedBy = "admin ";

                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = _dateTimeService.NowUtc;
                        entry.Entity.LastModifiedBy = "admin";
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync();
        }

    }
}