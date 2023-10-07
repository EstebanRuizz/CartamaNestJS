using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Enviroment;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;

namespace Parque.Application.Features.Enviromments.Queries.GetByIdAsync
{
    public class GetByIdEnviromentQuery : IRequest<GenericResponse<EnviromentDTO>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdEnviromentQueryHandler : IRequestHandler<GetByIdEnviromentQuery, GenericResponse<EnviromentDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Enviroment> _repositoryAsync;


        public GetByIdEnviromentQueryHandler(IMapper mapper, IRepositoryAsync<Enviroment> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<EnviromentDTO>> Handle(GetByIdEnviromentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var environmet = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (environmet == null)
                     throw new KeyNotFoundException($"The environment with id {request.Id} does not exist");

                return new GenericResponse<EnviromentDTO>(_mapper.Map<EnviromentDTO>(environmet));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
