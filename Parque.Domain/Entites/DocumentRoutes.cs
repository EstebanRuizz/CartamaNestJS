using Parque.Domain.BaseEntity;

namespace Parque.Domain.Entites
{
    public class DocumentRoutes : AuditableBaseEntity
    {
        public string BaseRoute { get; set; }
        public string Name { get; set; }

    }
}
