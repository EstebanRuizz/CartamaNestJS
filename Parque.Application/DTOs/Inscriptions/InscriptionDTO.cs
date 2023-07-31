using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.DTOs.Inscriptions
{
    public class InscriptionDTO
    {
        public int Id { get; set; }
        public string NameUser { get; set; }
        public string NamePublication { get; set; }
        public string UserDocumentRoute { get; set; }
    }
}
