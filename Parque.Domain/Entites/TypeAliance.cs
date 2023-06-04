using Parque.Domain.BaseEntity;

namespace Parque.Domain.Entites
{
    public class TypeAliance : AuditableBaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Aliance> Aliances { get; } = new List<Aliance>();
    }
}
