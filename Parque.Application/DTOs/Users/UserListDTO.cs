using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.DTOs.Users
{
    public class UserListDTO
    {
        public int Id { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string IdTypeDocument { get; set; }
        public string IdRol { get; set; }
    }
}
