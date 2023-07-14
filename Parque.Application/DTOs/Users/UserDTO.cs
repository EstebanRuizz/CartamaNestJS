using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.DTOs.Users
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string IdentityDocument { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ProfilePictureRoute { get; set; }
        public string IdTypeDocument { get; set; }
        public string IdRol { get; set; }
        //public virtual Rol? IdRolNavigation { get; set; }
        //public virtual TypeDocument IdTypeDocumentNavigation { get; set; }
        //public virtual ICollection<Inscription> Inscriptions { get; } = new List<Inscription>();
        //public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
    }
}
