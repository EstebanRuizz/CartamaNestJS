using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.DTOs.Publication
{
    public class ListPublicationDTO
    {
      public int Id { get; set; }
      public string Title { get; set; }
      public string HasForm { get; set; }
      public string Description { get; set; }
      public string ImageRoute { get; set; }
      public string CreatedDate { get; set; }
      public int IdTypeOfPublication { get; set; }
      public string NameTypePulblication { get; set; }
    }
}
