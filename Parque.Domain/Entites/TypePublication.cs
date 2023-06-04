using Parque.Domain.BaseEntity;

namespace Parque.Domain.Entites
{
    public class TypePublication : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }


        public ICollection<Publication> Publications { get; } = new List<Publication>();
    }
}
