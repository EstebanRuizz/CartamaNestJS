using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Publication;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Publications.Queries.GetAllPublications
{
    public class GetAllPublicationsQuery : IRequest<GenericResponse<List<ListPublicationDTO>>>
    {
    }
    internal class GetAllPublicationsQueryHandler : IRequestHandler<GetAllPublicationsQuery, GenericResponse<List<ListPublicationDTO>>>
    {
        private readonly IRepositoryAsync<Publication> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllPublicationsQueryHandler(IRepositoryAsync<Publication> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<ListPublicationDTO>>> Handle(GetAllPublicationsQuery request, CancellationToken cancellationToken)
        {
            var publications = await _repositoryAsync.GetAllAsync();
            var ListPublications = _mapper.Map<List<ListPublicationDTO>>(publications);

            return new GenericResponse<List<ListPublicationDTO>>(ListPublications);
        }
    }
}
