using AutoMapper;
using Parque.Application.DTOs.Aliances;
using Parque.Application.DTOs.Enviroment;
using Parque.Application.DTOs.Roles;
using Parque.Application.DTOs.Users;
using Parque.Application.Features.Aliances.Commands.CreateAliances;
using Parque.Domain.Entites;

namespace Parque.Application.Mappings
{
    public class GeneralProfile : Profile
    {

        public GeneralProfile()
        {
            CreateMap<Aliance, AliancesDTO>()
                .ForMember(p => p.TypeAliance, options => options.MapFrom(origen => origen.IdTypeAliancesNavigation.Name));
            CreateMap<CreateAliancesCommand, Aliance>(); // Mapeo de CreateAliancesCommand a Aliance


            CreateMap<Enviroment, EnviromentDTO>().ReverseMap();

            //Maritza retirar despues
            CreateMap<User, UserListDTO>()
                .ForMember(
                    user => user.IdTypeDocument, 
                    options => options.MapFrom(origin => origin.IdTypeDocumentNavigation.Name));

            CreateMap<User, UserDTO>().ForMember(u => u.IdTypeDocument, options => options.MapFrom(origen => origen.IdTypeDocumentNavigation.Name))
            .ForMember(u => u.IdRol, options => options.MapFrom(origen => origen.IdRolNavigation.Name));

            CreateMap<Rol, RolesDTO>().ReverseMap();
        }
    }
}
