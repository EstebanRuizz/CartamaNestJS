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

namespace Parque.Application.Features.TypeAliances.Queries.GetByIdTypeAliances
{
    public class GetByIdTypeAliancesQuery : IRequest<GenericResponse<TypeAlianceDTO>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdTypeAliancesQueryHandler : IRequestHandler<GetByIdTypeAliancesQuery, GenericResponse<TypeAlianceDTO>>
    {
        private readonly IRepositoryAsync<TypeAliance> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdTypeAliancesQueryHandler(IRepositoryAsync<TypeAliance> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<TypeAlianceDTO>> Handle(GetByIdTypeAliancesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var typeAliance = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (typeAliance == null)
                    throw new KeyNotFoundException($"Tipo de alianza con el id: {request.Id} no existe");

                return new GenericResponse<TypeAlianceDTO>(_mapper.Map<TypeAlianceDTO>(typeAliance));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
