using Parque.Domain.BaseEntity;

namespace Parque.Domain.Entites
{
    public class Inscription : AuditableBaseEntity
    {
        public int IdUser { get; set; }
        public int IdPublication { get; set; }
        public string UserDocumentRoute { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual Publication IdPublicationNavigation { get; set; }
    }
}
