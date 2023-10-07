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

namespace Parque.Application.Features.Inscriptions.Queries.GetAllInscriptions
{
    public class GetAllnscriptionsQuery : IRequest<GenericResponse<List<InscriptionDTO>>>
    {
    }

    internal class GetAllnscriptionsQueryHandler : IRequestHandler<GetAllnscriptionsQuery, GenericResponse<List<InscriptionDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Inscription> _repositoryAsync;

        public GetAllnscriptionsQueryHandler(IMapper mapper, IRepositoryAsync<Inscription> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<List<InscriptionDTO>>> Handle(GetAllnscriptionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var publications = await _repositoryAsync.GetAllAsync(includeProperties: $"{nameof(Inscription.IdPublicationNavigation)},{nameof(Inscription.IdUserNavigation)}");
                return new GenericResponse<List<InscriptionDTO>>(_mapper.Map<List<InscriptionDTO>>(publications.ToList()));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
