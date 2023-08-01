using Parque.Domain.BaseEntity;

namespace Parque.Domain.Entites
{
    public class User : AuditableBaseEntity
    {
        public string NationalIdentificationNumber { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ProfilePictureRoute { get; set; }
        public int IdTypeDocument { get; set; }
        public int IdRol { get; set; }
        public virtual Rol? IdRolNavigation { get; set; }
        public virtual TypeDocument IdTypeDocumentNavigation { get; set; }
        public virtual ICollection<Inscription> Inscriptions { get; } = new List<Inscription>();
        public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
    }
}
