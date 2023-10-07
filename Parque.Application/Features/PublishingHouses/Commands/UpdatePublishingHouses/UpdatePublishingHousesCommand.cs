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

namespace Parque.Application.Features.PublishingHouses.Commands.UpdatePublishingHouses
{
    public class UpdatePublishingHousesCommand : IRequest<GenericResponse<PublishingHouseDTO>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    internal class UpdatePublishingHousesCommandHandler : IRequestHandler<UpdatePublishingHousesCommand, GenericResponse<PublishingHouseDTO>>
    {
        private readonly IRepositoryAsync<PublishingHouse> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdatePublishingHousesCommandHandler(IRepositoryAsync<PublishingHouse> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<PublishingHouseDTO>> Handle(UpdatePublishingHousesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var publishingHouse = await _repositoryAsync.GetAsync(ph => ph.Id == request.Id);
                if (publishingHouse == null)
                    throw new KeyNotFoundException($"Editorial con el id: {request.Id} no existe");

                publishingHouse.Name = request.Name;

                await _repositoryAsync.UpdateAsync(publishingHouse);
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
