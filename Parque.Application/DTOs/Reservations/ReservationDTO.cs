using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.DTOs.Reservations
{
    public class ReservationDTO
    {
        public int Id {  get; set; }
        public string Description { get; set; }
        public int IdUser { get; set; }
        public int IdEnviroment { get; set; }
    }
}
