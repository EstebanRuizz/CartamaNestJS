using AutoMapper;
using MediatR;
using Parque.Application.DTOs.PublishingHouse;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.PublishingHouses.Queries.GetByIdPublishingHouses
{
    public class GetByIdPublishingHousesQuery : IRequest<GenericResponse<PublishingHouseDTO>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdPublishingHousesQueryHandler : IRequestHandler<GetByIdPublishingHousesQuery, GenericResponse<PublishingHouseDTO>>
    {
        private readonly IRepositoryAsync<PublishingHouse> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdPublishingHousesQueryHandler(IRepositoryAsync<PublishingHouse> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<PublishingHouseDTO>> Handle(GetByIdPublishingHousesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var publishingHouse = await _repositoryAsync.GetAsync(ph => ph.Id == request.Id);
                if (publishingHouse == null)
                    throw new KeyNotFoundException($"Editorial con el id: {request.Id} no existe");

                return new GenericResponse<PublishingHouseDTO>(_mapper.Map<PublishingHouseDTO>(publishingHouse));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
