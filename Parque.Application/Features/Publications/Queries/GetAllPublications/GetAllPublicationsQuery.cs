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
        public int Limit { get; set; }
        public int Offset { get; set; }

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
            var publications = await _repositoryAsync.GetAllAsync(includeProperties: $"{nameof(Publication.IdTypePublicationNavigation)}");
            var pagination = publications.Skip(request.Offset).Take(request.Limit);
            return new GenericResponse<List<ListPublicationDTO>>(_mapper.Map<List<ListPublicationDTO>>(pagination.ToList()));
        }
    }
}
