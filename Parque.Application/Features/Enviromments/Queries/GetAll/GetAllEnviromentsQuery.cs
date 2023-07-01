using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Enviroment;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;

namespace Parque.Application.Features.Enviromments.Queries.GetAll
{
    public class GetAllEnviromentsQuery : IRequest<GenericResponse<List<EnviromentDTO>>>
    {

    }

    internal class GetAllEnviromentsQueryHandler : IRequestHandler<GetAllEnviromentsQuery, GenericResponse<List<EnviromentDTO>>>
    {
        private readonly IRepositoryAsync<Enviroment> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllEnviromentsQueryHandler(IRepositoryAsync<Enviroment> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<EnviromentDTO>>> Handle(GetAllEnviromentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var listEnviroment = await _repositoryAsync.GetAllAsync();

                return new GenericResponse<List<EnviromentDTO>>(_mapper.Map<List<EnviromentDTO>>(listEnviroment.ToList()));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
