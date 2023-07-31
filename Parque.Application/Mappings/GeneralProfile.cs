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
using Parque.Application.Features.TypeAliances.Commands.CreateTypeAliance;
using Parque.Application.Features.TypeDocuments.Commands.CreateTypeDocument;
using Parque.Domain.Entites;
using Parque.Application.DTOs.TypePublications;
using Parque.Application.Features.TypePublications.Commands.CreateTypePublications;
using Parque.Application.Features.PublishingHouses.Commands.CreatePublishingHouses;
using Parque.Application.DTOs.PublishingHouse;
using Parque.Application.Features.Inscriptions.Commands.CreateInscriptions;
using Parque.Application.DTOs.Inscriptions;
using Parque.Application.Features.NewsPapers.Commands.CreateNewsPapers;
using Parque.Application.DTOs.NewsPapers;
using Parque.Application.DTOs.Reservations;
using Parque.Application.Features.Reservations.Commands.CreateReservations;
using Parque.Application.Features.Enviromments.Commands.Create;
using Parque.Application.Features.Aliances.Commands.UpdateAliances;

namespace Parque.Application.Mappings
{
    public class GeneralProfile : Profile
    {

        public GeneralProfile()
        {
            CreateMap<Aliance, AliancesDTO>()
                .ForMember(p => p.TypeAliance, options => options.MapFrom(origen => origen.IdTypeAliancesNavigation.Name))       
                .ForMember(p => p.IdTypeAliance, options => options.MapFrom(origen => origen.IdTypeAliancesNavigation.Id));            
            CreateMap<CreateAliancesCommand, Aliance>();

            CreateMap<Enviroment, EnviromentDTO>().ReverseMap();
            CreateMap<CreateEnviromentCommand, Enviroment>();

            CreateMap<Inscription, InscriptionDTO>()
                .ForMember(p => p.NameUser, options => options.MapFrom(origen => origen.IdUserNavigation.FirstName))
                .ForMember(p => p.NamePublication, options => options.MapFrom(origen => origen.IdPublicationNavigation.Title));
            CreateMap<CreateInscriptionsCommand, Inscription>();

            CreateMap<NewsPaper, NewsPaperDTO>()
                .ForMember(p => p.PublishingHouse, options => options.MapFrom(origen => origen.IdPublishingHouseNavigation.Name));
            CreateMap<CreateNewsPapersCommand, NewsPaper>();

            CreateMap<Publication, ListPublicationDTO>()
                .ForMember(publication => publication.TypeOfPulblication, options => options.MapFrom(origin => origin.IdTypePublicationNavigation.Name));
            CreateMap<Publication, CreatePublicationCommand>();
            CreateMap<CreatePublicationCommand, Publication>();

            CreateMap<PublishingHouse, PublishingHouseDTO>().ReverseMap();
            CreateMap<CreatePublishingHousesCommand, PublishingHouse>();

            CreateMap<Reservation, ReservationDTO>()
                .ForMember(p => p.IdEnviroment, options => options.MapFrom(origen => origen.IdEnvironmentNavigation.Title))
                .ForMember(p => p.IdUser, options => options.MapFrom(origen => origen.IdUserNavigation.FirstName));
            CreateMap<CreateReservationsCommand, Reservation>();

            CreateMap<Rol, RolesDTO>().ReverseMap();
            CreateMap<CreateRolesCommand, Rol>();

            CreateMap<TypeAliance, TypeAlianceDTO>().ReverseMap();
            CreateMap<CreateTypeAlianceCommand, TypeAliance>();

            CreateMap<TypeDocument, TypeDocumentDTO>().ReverseMap();
            CreateMap<CreateTypeDocumentCommand, TypeDocument>().ReverseMap();

            CreateMap<TypePublication, TypePublicationsDTO>().ReverseMap();
            CreateMap<CreateTypePublicationsCommand, TypePublication>();

            CreateMap<User, UserListDTO>()
                .ForMember(user => user.IdTypeDocument, options => options.MapFrom(origin => origin.IdTypeDocumentNavigation.Name));
            CreateMap<User, UserDTO>()
                .ForMember(u => u.IdTypeDocument, options => options.MapFrom(origen => origen.IdTypeDocumentNavigation.Name))
                .ForMember(u => u.IdRol, options => options.MapFrom(origen => origen.IdRolNavigation.Name));
            CreateMap<CreateUserCommand, User>(); // from CreateUserCommand To User
            CreateMap<User, CreateUserCommand>();
        }
    }
}
