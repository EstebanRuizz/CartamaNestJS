using Parque.Domain.BaseEntity;

namespace Parque.Domain.Entites
{
    public class NewsPaper : AuditableBaseEntity
    {
        public string Title { get; set; }
        public int IdPublishingHouse { get; set; }
        public string DocumentRoute { get; set; }
        public virtual PublishingHouse IdPublishingHouseNavigation { get; set; }
    }
}
