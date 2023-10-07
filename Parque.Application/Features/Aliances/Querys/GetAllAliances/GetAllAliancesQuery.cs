using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Aliances;
using Parque.Application.DTOs.Inscriptions;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;

namespace Parque.Application.Features.Aliances.Querys.GetAllAliances
{
    public class GetAllAliancesQuery : IRequest<GenericResponse<List<AliancesDTO>>>
    {
    }

    public class GetAllAliancesQueryHandler : IRequestHandler<GetAllAliancesQuery, GenericResponse<List<AliancesDTO>>>
    {
        private readonly IRepositoryAsync<Aliance> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllAliancesQueryHandler(IRepositoryAsync<Aliance> aliancesRepository, IMapper mapper)
        {
            _repositoryAsync = aliancesRepository;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<AliancesDTO>>> Handle(GetAllAliancesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var alices = await _repositoryAsync.GetAllAsync(includeProperties: $"{nameof(Aliance.IdTypeAliancesNavigation)}");
                return new GenericResponse<List<AliancesDTO>>(_mapper.Map<List<AliancesDTO>>(alices.ToList()));
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
