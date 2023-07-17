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

namespace Parque.Application.Features.PublishingHouses.Queries.GetAllPublishingHouses
{
    public class GetAllPublishingHousesQuery : IRequest<GenericResponse<List<PublishingHouseDTO>>>
    {
    }

    internal class GetAllPublishingHousesQueryHandler : IRequestHandler<GetAllPublishingHousesQuery, GenericResponse<List<PublishingHouseDTO>>>
    {
        private readonly IRepositoryAsync<PublishingHouse> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllPublishingHousesQueryHandler(IRepositoryAsync<PublishingHouse> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<PublishingHouseDTO>>> Handle(GetAllPublishingHousesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var publishingHouse = await _repositoryAsync.GetAllAsync();
                return new GenericResponse<List<PublishingHouseDTO>>(_mapper.Map<List<PublishingHouseDTO>>(publishingHouse));   
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
