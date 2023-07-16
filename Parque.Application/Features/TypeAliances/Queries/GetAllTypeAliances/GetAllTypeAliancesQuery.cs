using AutoMapper;
using MediatR;
using Parque.Application.DTOs.TypeAliance;
using Parque.Application.DTOs.TypePublications;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.TypeAliances.Queries.GetAllTypeAliances
{
    public class GetAllTypeAliancesQuery : IRequest<GenericResponse<List<TypeAlianceDTO>>>
    {
    }

    internal class GetAllTypeAliancesQueryHandler : IRequestHandler<GetAllTypeAliancesQuery, GenericResponse<List<TypeAlianceDTO>>>
    {
        private readonly IRepositoryAsync<TypeAliance> _repositorioAsync;
        private readonly IMapper _mapper;

        public GetAllTypeAliancesQueryHandler(IRepositoryAsync<TypeAliance> repositorioAsync, IMapper mapper)
        {
            _repositorioAsync = repositorioAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<TypeAlianceDTO>>> Handle(GetAllTypeAliancesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var typeAliance = await _repositorioAsync.GetAllAsync();
                return new GenericResponse<List<TypeAlianceDTO>>(_mapper.Map<List<TypeAlianceDTO>>(typeAliance));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
