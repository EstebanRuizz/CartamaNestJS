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

namespace Parque.Application.Features.Inscriptions.Commands.CreateInscriptions
{
    public class CreateInscriptionsCommand : IRequest<GenericResponse<InscriptionDTO>>
    {
        public int IdUser { get; set; }
        public int IdPublication { get; set; }
        public string UserDocumentRoute { get; set; }
    }

    internal class CreateInscriptionsCommandHandler : IRequestHandler<CreateInscriptionsCommand, GenericResponse<InscriptionDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Inscription> _repositoryAsync;

        public CreateInscriptionsCommandHandler(IMapper mapper, IRepositoryAsync<Inscription> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<InscriptionDTO>> Handle(CreateInscriptionsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Inscription inscription = _mapper.Map<CreateInscriptionsCommand, Inscription>(request);
                var newInscription = await _repositoryAsync.CreateAsync(inscription);
                await _repositoryAsync.SaveChangesAsync();

                var getInscription = await _repositoryAsync.GetAsync(p => p.Id == newInscription.Id, includeProperties: $"{nameof(Inscription.IdPublicationNavigation)},{nameof(Inscription.IdUserNavigation)}");

                return new GenericResponse<InscriptionDTO>(_mapper.Map<InscriptionDTO>(newInscription));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
