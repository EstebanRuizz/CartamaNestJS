using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Aliances;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;

namespace Parque.Application.Features.Aliances.Querys.GetAllAliances
{
    public class GetAllAliancesQuery : IRequest<GenericResponse<List<AliancesDTO>>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string Nombre { get; set; }
        public string FechaAlianza { get; set; }
        public int? TypeAliance { get; set; }

    }

    public class GetAllAliancesQueryHandler : IRequestHandler<GetAllAliancesQuery, GenericResponse<List<AliancesDTO>>>
    {
        private readonly IAliancesRepository _aliancesRepository;
        private readonly IMapper _mapper;

        public GetAllAliancesQueryHandler(IMapper mapper,
        IAliancesRepository aliancesRepository)
        {

            _mapper = mapper;
            _aliancesRepository = aliancesRepository;
        }

        public async Task<GenericResponse<List<AliancesDTO>>> Handle(GetAllAliancesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var aliances = await _aliancesRepository.GetAllAliances();

                return new GenericResponse<List<AliancesDTO>>(_mapper.Map<List<AliancesDTO>>(aliances));

            }
            catch (Exception)
            {

                throw;
            }

        }

    }


}
