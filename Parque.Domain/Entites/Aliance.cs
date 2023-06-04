using Parque.Domain.BaseEntity;

namespace Parque.Domain.Entites
{
    public class Aliance : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string AlianceDate { get; set; }
        public string Description { get; set; }
        public int IdTypeAliance { get; set; }
        public string DocumentRoute { get; set; }
        public virtual TypeAliance IdTypeAliancesNavigation { get; set; }
    }
}
