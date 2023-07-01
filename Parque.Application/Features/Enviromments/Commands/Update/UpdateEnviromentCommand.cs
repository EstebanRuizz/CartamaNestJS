using MediatR;
using Parque.Application.Exceptions;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;

namespace Parque.Application.Features.Enviromments.Commands.Update
{
    public class UpdateEnviromentCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DocumentRoute { get; set; }
    }

    internal class UpdateEnviromentCommandHandler : IRequestHandler<UpdateEnviromentCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<Enviroment> _repositoryAsync;

        public UpdateEnviromentCommandHandler(IRepositoryAsync<Enviroment> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }


        public async Task<GenericResponse<bool>> Handle(UpdateEnviromentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Enviroment entity = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (entity == null)
                    throw new ApiException("El ambiente no fue encontrado");

                entity.Title = request.Title;
                entity.DocumentRoute = request.DocumentRoute;
                entity.Description = request.Description;
                bool result = await _repositoryAsync.UpdateAsync(entity);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<bool>(result);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
