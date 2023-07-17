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

namespace Parque.Application.Features.TypePublications.Queries.GetByIdTypePublications
{
    public class GetByIdTypePublicationsQuery : IRequest<GenericResponse<TypePublicationsDTO>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdTypePublicationsQueryHandler : IRequestHandler<GetByIdTypePublicationsQuery, GenericResponse<TypePublicationsDTO>>
    {
        private readonly IRepositoryAsync<TypePublication> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdTypePublicationsQueryHandler(IRepositoryAsync<TypePublication> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<TypePublicationsDTO>> Handle(GetByIdTypePublicationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var typePublication = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (typePublication == null)
                    throw new KeyNotFoundException($"Tipo de publicación con el id: {request.Id} no existe");

                return new GenericResponse<TypePublicationsDTO>(_mapper.Map<TypePublicationsDTO>(typePublication));                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
