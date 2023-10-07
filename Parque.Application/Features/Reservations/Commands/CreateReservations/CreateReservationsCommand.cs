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

namespace Parque.Application.Features.Reservations.Commands.CreateReservations
{
    public class CreateReservationsCommand : IRequest<GenericResponse<ReservationDTO>>
    {        
        public string Description { get; set; }
        public int IdUser { get; set; }
        public int IdEnviroment { get; set; }
    }

    internal class CreateReservationsCommandHandler : IRequestHandler<CreateReservationsCommand, GenericResponse<ReservationDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Reservation> _repositoryAsync;

        public CreateReservationsCommandHandler(IMapper mapper, IRepositoryAsync<Reservation> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<ReservationDTO>> Handle(CreateReservationsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Reservation reservation = _mapper.Map<CreateReservationsCommand, Reservation>(request);
                var newReservation = await _repositoryAsync.CreateAsync(reservation);
                await _repositoryAsync.SaveChangesAsync();
                return new GenericResponse<ReservationDTO>(_mapper.Map<ReservationDTO>(newReservation));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
