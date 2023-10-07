using AutoMapper;
using MediatR;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.PublishingHouses.Commands.DeletePublishingHouses
{
    public class DeletePublishingHousesCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    internal class DeletePublishingHousesCommandHandler : IRequestHandler<DeletePublishingHousesCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<PublishingHouse> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeletePublishingHousesCommandHandler(IRepositoryAsync<PublishingHouse> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<bool>> Handle(DeletePublishingHousesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var publishingHouse = await _repositoryAsync.GetAsync(ph => ph.Id == request.Id);
                if (publishingHouse == null)
                    throw new KeyNotFoundException($"Editorial con el id: {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(publishingHouse);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<bool>(true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
