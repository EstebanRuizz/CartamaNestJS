using Parque.Domain.BaseEntity;

namespace Parque.Domain.Entites
{
    public class Reservation : AuditableBaseEntity
    {
        public string Description { get; set; }
        public int IdUser { get; set; }
        public int IdEnviroment { get; set; }
        public virtual Environment IdEnvironmentNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}