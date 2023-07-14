using AutoMapper;
using Parque.Application.DTOs.Aliances;
using Parque.Application.DTOs.Enviroment;
using Parque.Application.DTOs.Users;
using Parque.Domain.Entites;

namespace Parque.Application.Mappings
{
    public class GeneralProfile : Profile
    {

        public GeneralProfile()
        {
            CreateMap<Aliance, AliancesDTO>().ForMember(p => p.TypeAliance, options => options.MapFrom(origen => origen.IdTypeAliancesNavigation.Name));
            CreateMap<Enviroment, EnviromentDTO>().ReverseMap();

            //Maritza retirar despues
            CreateMap<User, UserDTO>().ForMember(u => u.IdTypeDocument, options => options.MapFrom(origen => origen.IdTypeDocumentNavigation.Name))
            .ForMember(u => u.IdRol, options => options.MapFrom(origen => origen.IdRolNavigation.Name));      

        }

    }
}
