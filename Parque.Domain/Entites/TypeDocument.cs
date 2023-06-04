using Parque.Domain.BaseEntity;

namespace Parque.Domain.Entites
{
    public class TypeDocument : AuditableBaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; } = new List<User>();
    }
}
