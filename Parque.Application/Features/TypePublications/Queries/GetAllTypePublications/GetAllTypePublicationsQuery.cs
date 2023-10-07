using AutoMapper;
using MediatR;
using Parque.Application.DTOs.TypePublications;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.TypePublications.Queries.GetAllTypePublications
{
    public class GetAllTypePublicationsQuery : IRequest<GenericResponse<List<TypePublicationsDTO>>>
    {
    }

    internal class GetAllTypePublicationsQueryHandler : IRequestHandler<GetAllTypePublicationsQuery, GenericResponse<List<TypePublicationsDTO>>>
    {
        private readonly IRepositoryAsync<TypePublication> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllTypePublicationsQueryHandler(IRepositoryAsync<TypePublication> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<TypePublicationsDTO>>> Handle(GetAllTypePublicationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var typePublicatios = await _repositoryAsync.GetAllAsync();
                return new GenericResponse<List<TypePublicationsDTO>>(_mapper.Map<List<TypePublicationsDTO>>(typePublicatios));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
