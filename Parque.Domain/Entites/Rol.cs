using Parque.Domain.BaseEntity;

namespace Parque.Domain.Entites
{
    public class Rol : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<User> Users { get; } = new List<User>();
    }
}
