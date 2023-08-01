using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Inscriptions;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Inscriptions.Queries.GetByIdInscriptions
{
    public class GetByIdInscriptionsQuery : IRequest<GenericResponse<InscriptionDTO>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdInscriptionsQueryHandler : IRequestHandler<GetByIdInscriptionsQuery, GenericResponse<InscriptionDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Inscription> _repositoryAsync;

        public GetByIdInscriptionsQueryHandler(IMapper mapper, IRepositoryAsync<Inscription> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<InscriptionDTO>> Handle(GetByIdInscriptionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var inscription = await _repositoryAsync.GetAsync(p => p.Id == request.Id, includeProperties: $"{nameof(Inscription.IdPublicationNavigation)},{nameof(Inscription.IdUserNavigation)}");

                if (inscription == null)
                    throw new KeyNotFoundException($"Inscription with id: {request.Id} does not exist");

                return new GenericResponse<InscriptionDTO>(_mapper.Map<InscriptionDTO>(inscription));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
