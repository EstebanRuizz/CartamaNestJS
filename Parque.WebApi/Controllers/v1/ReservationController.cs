using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Parque.Application.Features.Reservations.Commands.CreateReservations;
using Parque.Application.Features.Reservations.Commands.DeleteReservations;
using Parque.Application.Features.Reservations.Commands.UpdateReservations;
using Parque.Application.Features.Reservations.Queries.GetAllReservations;
using Parque.Application.Features.Reservations.Queries.GetByIdReservation;

namespace Parque.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]  
    public class ReservationController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllReservationsQuery()));  
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetByIdReservationQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateReservationsCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateReservationsCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteReservationsCommand { Id = id }));  
        }
    }
}
