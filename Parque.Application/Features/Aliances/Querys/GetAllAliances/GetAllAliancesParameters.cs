using Parque.Application.Parameters;

namespace Parque.Application.Features.Aliances.Querys.GetAllAliances
{
    public class GetAllAliancesParameters : RequestedParameters
    {
        public string Nombre { get; set; }
        public string FechaAlianza { get; set; }
        public int TypeAliance { get; set; }

    }
}
