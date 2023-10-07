using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Parque.Application.DTOs.Reservations;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Reservations.Queries.GetAllReservations
{
    public class GetAllReservationsQuery : IRequest<GenericResponse<List<ReservationDTO>>>
    {
    }

    internal class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, GenericResponse<List<ReservationDTO>>>
    {
        private readonly IRepositoryAsync<Reservation> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllReservationsQueryHandler(IRepositoryAsync<Reservation> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<ReservationDTO>>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var reservations = await _repositoryAsync.GetAllAsync();
                if (reservations  == null)
                 
                    throw new KeyNotFoundException("Aún no hay reservas");

                return new GenericResponse<List<ReservationDTO>>(_mapper.Map<List<ReservationDTO>>(reservations));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
