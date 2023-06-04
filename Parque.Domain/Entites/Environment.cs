using Parque.Domain.BaseEntity;

namespace Parque.Domain.Entites
{
    public class Environment : AuditableBaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string DocumentRoute { get; set; }


        public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
    }
}