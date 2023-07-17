using AutoMapper;
using Parque.Application.DTOs.Aliances;
using Parque.Application.DTOs.Enviroment;
using Parque.Application.DTOs.Publication;
using Parque.Application.DTOs.Roles;
using Parque.Application.DTOs.TypeAliance;
using Parque.Application.DTOs.TypeDocument;
using Parque.Application.DTOs.Users;
using Parque.Application.Features.Aliances.Commands.CreateAliances;

using Parque.Application.Features.Publications.Commands.CreatePublication;
using Parque.Application.Features.Users.Commands.CreateUsers;

using Parque.Application.Features.Roles.Commands.CreateRoles;
using Parque.Application.Features.Roles.Commands.UpdateRoles;
using Parque.Application.Features.TypeAliances.Commands.CreateTypeAliance;
using Parque.Application.Features.TypeDocuments.Commands.CreateTypeDocument;

using Parque.Domain.Entites;
using Parque.Application.DTOs.TypePublications;
using Parque.Application.Features.TypePublications.Commands.CreateTypePublications;
using Parque.Application.Features.PublishingHouses.Commands.CreatePublishingHouses;
using Parque.Application.DTOs.PublishingHouse;

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

            CreateMap<Publication, CreatePublicationCommand>();
            CreateMap<CreatePublicationCommand, Publication>();
            CreateMap<Publication, ListPublicationDTO>()
                .ForMember(publication => publication.TypeOfPulblication, options => options.MapFrom(origin => origin.IdTypePublicationNavigation.Name));

            CreateMap<CreateUserCommand, User>(); // from CreateUserCommand To User
            CreateMap<User, CreateUserCommand>();
            CreateMap<User, UserListDTO>()
                .ForMember(user => user.IdTypeDocument, options => options.MapFrom(origin => origin.IdTypeDocumentNavigation.Name));
            CreateMap<User, UserDTO>()
                .ForMember(u => u.IdTypeDocument, options => options.MapFrom(origen => origen.IdTypeDocumentNavigation.Name))
                .ForMember(u => u.IdRol, options => options.MapFrom(origen => origen.IdRolNavigation.Name));

            CreateMap<Rol, RolesDTO>().ReverseMap();
            CreateMap<CreateRolesCommand, Rol>();

            CreateMap<TypeAliance, TypeAlianceDTO>().ReverseMap();
            CreateMap<CreateTypeAlianceCommand, TypeAliance>();


            CreateMap<TypeDocument, TypeDocumentDTO>().ReverseMap();
            CreateMap<CreateTypeDocumentCommand, TypeDocument>().ReverseMap();

            CreateMap<TypePublication, TypePublicationsDTO>().ReverseMap();
            CreateMap<CreateTypePublicationsCommand, TypePublication>();

            CreateMap<PublishingHouse, PublishingHouseDTO>().ReverseMap();
            CreateMap<CreatePublishingHousesCommand, PublishingHouse>();

        }
    }
}
