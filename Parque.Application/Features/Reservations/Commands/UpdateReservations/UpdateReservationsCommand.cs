using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Reservations;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Reservations.Commands.UpdateReservations
{
    public class UpdateReservationsCommand : IRequest<GenericResponse<ReservationDTO>>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int IdUser { get; set; }
        public int IdEnviroment { get; set; }
    }

    internal class UpdateReservationsCommandHandler : IRequestHandler<UpdateReservationsCommand, GenericResponse<ReservationDTO>>
    {
        private readonly IRepositoryAsync<Reservation> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateReservationsCommandHandler(IRepositoryAsync<Reservation> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<ReservationDTO>> Handle(UpdateReservationsCommand request, CancellationToken cancellationToken)
        {
            try
            {
               var reservation = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (reservation == null)
                    throw new KeyNotFoundException($"Reserva con el id {request.Id} no existe");

                await _repositoryAsync.UpdateAsync(reservation);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<ReservationDTO>(_mapper.Map<ReservationDTO>(reservation));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
