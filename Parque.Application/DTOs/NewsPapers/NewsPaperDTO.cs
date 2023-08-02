using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.DTOs.NewsPapers
{
    public class NewsPaperDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int IdPublishingHouse { get; set; }
        public string NamePublishingHouse { get; set; }
        public string DocumentRoute { get; set; }
    }
}
