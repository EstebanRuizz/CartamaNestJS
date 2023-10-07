using MediatR;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;

namespace Parque.Application.Features.Aliances.Commands.DeleteAliances
{
    public class DeleteAliancesCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteAliancesCommandHandler : IRequestHandler<DeleteAliancesCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<Aliance> _repositoryAsync;

        public DeleteAliancesCommandHandler(IRepositoryAsync<Aliance> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteAliancesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var alianza = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (alianza == null)
                    throw new KeyNotFoundException($"Alinaza con el id: {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(alianza);
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
