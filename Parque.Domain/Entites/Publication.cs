using Parque.Domain.BaseEntity;

namespace Parque.Domain.Entites
{
    public class Publication : AuditableBaseEntity
    {
        public string Title { get; set; }
        public bool HasForm { get; set; }
        public int IdTypeOfPulblication { get; set; }
        public string Description { get; set; }
        public string ImageRoute { get; set; }

        public virtual TypePublication IdTypePublicationNavigation { get; set; }
        public virtual ICollection<Inscription> Inscriptions { get; } = new List<Inscription>();
    }
}
