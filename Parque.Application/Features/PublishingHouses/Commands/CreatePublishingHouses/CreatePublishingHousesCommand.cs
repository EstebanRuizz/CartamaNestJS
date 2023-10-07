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

namespace Parque.Application.Features.PublishingHouses.Commands.CreatePublishingHouses
{
    public class CreatePublishingHousesCommand : IRequest<GenericResponse<PublishingHouseDTO>>
    {
        public string Name { get; set; }
    }

    internal class CreatePublishingHousesCommandHandler : IRequestHandler<CreatePublishingHousesCommand, GenericResponse<PublishingHouseDTO>>
    {
        private readonly IRepositoryAsync<PublishingHouse> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreatePublishingHousesCommandHandler(IRepositoryAsync<PublishingHouse> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<PublishingHouseDTO>> Handle(CreatePublishingHousesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                PublishingHouse newPublishingHouse = _mapper.Map<CreatePublishingHousesCommand, PublishingHouse>(request);
                var publishingHouse = await _repositoryAsync.CreateAsync(newPublishingHouse);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<PublishingHouseDTO>(_mapper.Map<PublishingHouseDTO>(publishingHouse));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
