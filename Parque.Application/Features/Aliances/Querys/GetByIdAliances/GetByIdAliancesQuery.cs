using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Aliances;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;

namespace Parque.Application.Features.Aliances.Querys.GetByIdAliances
{
    public class GetByIdAliancesQuery : IRequest<GenericResponse<AliancesDTO>>
    {
        public int Id { get; set; }

    }

    public class GetByIdAliancesQueryHandler : IRequestHandler<GetByIdAliancesQuery, GenericResponse<AliancesDTO>>
    {
        private readonly IRepositoryAsync<Aliance> _repositoryAsync;
        private readonly IMapper _mapper;
        public GetByIdAliancesQueryHandler(IRepositoryAsync<Aliance> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<AliancesDTO>> Handle(GetByIdAliancesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var alianza = await _repositoryAsync.GetAsync(p => p.Id == request.Id);

                if (alianza == null)
                    throw new KeyNotFoundException($"Alinaza con el id: {request.Id} no existe");

                return new GenericResponse<AliancesDTO>(_mapper.Map<AliancesDTO>(alianza));

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
