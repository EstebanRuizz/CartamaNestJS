using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Enviroment;
using Parque.Application.Exceptions;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;

namespace Parque.Application.Features.Enviromments.Commands.Update
{
    public class UpdateEnviromentCommand : IRequest<GenericResponse<EnviromentDTO>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DocumentRoute { get; set; }
    }

    internal class UpdateEnviromentCommandHandler : IRequestHandler<UpdateEnviromentCommand, GenericResponse<EnviromentDTO>>
    {
        private readonly IRepositoryAsync<Enviroment> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateEnviromentCommandHandler(IRepositoryAsync<Enviroment> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }


        public async Task<GenericResponse<EnviromentDTO>> Handle(UpdateEnviromentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Enviroment enviroment = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (enviroment == null)
                    throw new ApiException($"The environment with id {request.Id} does not exist");

                enviroment.Title = request.Title;
                enviroment.DocumentRoute = request.DocumentRoute;
                enviroment.Description = request.Description;
                var updateEnviroment = await _repositoryAsync.UpdateAsync(enviroment);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<EnviromentDTO>(_mapper.Map<EnviromentDTO>(updateEnviroment));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
