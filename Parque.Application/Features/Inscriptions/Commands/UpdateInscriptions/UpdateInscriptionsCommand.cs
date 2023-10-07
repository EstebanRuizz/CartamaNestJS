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

namespace Parque.Application.Features.Inscriptions.Commands.UpdateInscriptions
{
    public class UpdateInscriptionsCommand : IRequest<GenericResponse<InscriptionDTO>>
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdPublication { get; set; }
        public string UserDocumentRoute { get; set; }
    }

    internal class UpdateInscriptionsCommandHandler : IRequestHandler<UpdateInscriptionsCommand, GenericResponse<InscriptionDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Inscription> _repositoryAsync;

        public UpdateInscriptionsCommandHandler(IMapper mapper, IRepositoryAsync<Inscription> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<InscriptionDTO>> Handle(UpdateInscriptionsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var inscription = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (inscription == null)
                    throw new KeyNotFoundException($"Inscription with id: {request.Id} does not exist");

                inscription.IdUser = request.IdUser; 
                inscription.IdPublication = request.IdPublication;
                inscription.UserDocumentRoute = request.UserDocumentRoute;

                await _repositoryAsync.UpdateAsync(inscription);
                await _repositoryAsync.SaveChangesAsync();

                var getInscription = await _repositoryAsync.GetAsync(p => p.Id == request.Id, includeProperties: $"{nameof(Inscription.IdPublicationNavigation)},{nameof(Inscription.IdUserNavigation)}");

                return new GenericResponse<InscriptionDTO>(_mapper.Map<InscriptionDTO>(getInscription));

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
