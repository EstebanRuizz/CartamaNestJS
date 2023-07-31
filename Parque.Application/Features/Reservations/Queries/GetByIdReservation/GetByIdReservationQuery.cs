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

namespace Parque.Application.Features.Reservations.Queries.GetByIdReservation
{
    public class GetByIdReservationQuery : IRequest<GenericResponse<ReservationDTO>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdReservationQueryHandler : IRequestHandler<GetByIdReservationQuery, GenericResponse<ReservationDTO>>
    {
        private readonly IRepositoryAsync<Reservation> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdReservationQueryHandler(IRepositoryAsync<Reservation> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<ReservationDTO>> Handle(GetByIdReservationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var reservation = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (reservation == null)
                    throw new KeyNotFoundException($"Reserva con el id {request.Id} no existe");
                
                return new GenericResponse<ReservationDTO>(_mapper.Map<ReservationDTO>(reservation));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
