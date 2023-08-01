using AutoMapper;
using MediatR;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Inscriptions.Commands.DeleteInscriptions
{
    public class DeleteInscriptionsCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    internal class DeleteInscriptionsCommandHandler : IRequestHandler<DeleteInscriptionsCommand, GenericResponse<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Inscription> _repositoryAsync;

        public DeleteInscriptionsCommandHandler(IMapper mapper, IRepositoryAsync<Inscription> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteInscriptionsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var inscription = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (inscription == null)
                    throw new KeyNotFoundException($"Inscription with id: {request.Id} does not exist");

                await _repositoryAsync.DeleteAsync(inscription);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<bool>(true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
