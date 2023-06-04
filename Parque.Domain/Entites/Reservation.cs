using Parque.Domain.BaseEntity;

namespace Parque.Domain.Entites
{
    public class Reservation : AuditableBaseEntity
    {
        public string Description { get; set; }
        public virtual Environment IdEnvironment { get; set; }
        public virtual User IdUser { get; set; }
    }
}