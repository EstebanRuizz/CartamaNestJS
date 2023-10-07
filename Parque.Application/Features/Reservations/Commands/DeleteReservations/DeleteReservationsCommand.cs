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

namespace Parque.Application.Features.Reservations.Commands.DeleteReservations
{
    public class DeleteReservationsCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    internal class DeleteReservationsCommandHandler : IRequestHandler<DeleteReservationsCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<Reservation> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteReservationsCommandHandler(IRepositoryAsync<Reservation> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteReservationsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var reservation = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (reservation == null)
                    throw new KeyNotFoundException($"Reserva con el id {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(reservation);
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
