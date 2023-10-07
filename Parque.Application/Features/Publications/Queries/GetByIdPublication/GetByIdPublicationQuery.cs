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

namespace Parque.Application.Features.Publications.Queries.GetByIdPublication
{
    public class GetByIdPublicationQuery : IRequest<GenericResponse<ListPublicationDTO>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdPublicationQueryHandler : IRequestHandler<GetByIdPublicationQuery, GenericResponse<ListPublicationDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Publication> _repositoryAsync;

        public GetByIdPublicationQueryHandler(IMapper mapper, IRepositoryAsync<Publication> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<ListPublicationDTO>> Handle(GetByIdPublicationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var publication = await _repositoryAsync.GetAsync(p => p.Id == request.Id, includeProperties: $"{nameof(Publication.IdTypePublicationNavigation)}");

                if (publication == null)
                    throw new KeyNotFoundException($"Publication with id: {request.Id} does not exist");

                return new GenericResponse<ListPublicationDTO>(_mapper.Map<ListPublicationDTO>(publication));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
