using Parque.Domain.BaseEntity;

namespace Parque.Domain.Entites
{
    public class Publishing : AuditableBaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<NewsPaper> NewsPapers { get; } = new List<NewsPaper>();
    }
}
