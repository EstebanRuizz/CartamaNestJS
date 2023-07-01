using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Enviroment;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;

namespace Parque.Application.Features.Enviromments.Commands.Create
{
    public class CreateEnviromentCommand : IRequest<GenericResponse<EnviromentDTO>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string DocumentRoute { get; set; }
    }


    internal class CreateEnviromentCommandHandler : IRequestHandler<CreateEnviromentCommand, GenericResponse<EnviromentDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Enviroment> _repository;

        public CreateEnviromentCommandHandler(IMapper mapper, IRepositoryAsync<Enviroment> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GenericResponse<EnviromentDTO>> Handle(CreateEnviromentCommand request, CancellationToken cancellationToken)
        {


            Enviroment entity = new Enviroment()
            {
                Title = request.Title,
                Description = request.Description,
                DocumentRoute = request.DocumentRoute
            };

            var dto = _mapper.Map<EnviromentDTO>(await _repository.CreateAsync(entity));
            await _repository.SaveChangesAsync();

            return new GenericResponse<EnviromentDTO>(dto);


        }
    }
}
