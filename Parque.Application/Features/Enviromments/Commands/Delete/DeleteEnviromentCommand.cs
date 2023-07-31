using AutoMapper;
using MediatR;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;

namespace Parque.Application.Features.Enviromments.Commands.Delete
{
    public class DeleteEnviromentCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    internal class DeleteEnviromentCommandHandler : IRequestHandler<DeleteEnviromentCommand, GenericResponse<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Enviroment> _repositoryAsync;

        public DeleteEnviromentCommandHandler(IMapper mapper, IRepositoryAsync<Enviroment> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteEnviromentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Enviroment enviroment = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (enviroment == null)
                    throw new KeyNotFoundException($"The environment with id {request.Id} does not exist");

                bool result = await _repositoryAsync.DeleteAsync(enviroment);
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
