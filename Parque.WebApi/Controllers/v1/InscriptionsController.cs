using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parque.Application.Features.Inscriptions.Commands.CreateInscriptions;
using Parque.Application.Features.Inscriptions.Commands.DeleteInscriptions;
using Parque.Application.Features.Inscriptions.Queries.GetAllInscriptions;
using Parque.Application.Features.Inscriptions.Queries.GetByIdInscriptions;
using Parque.Application.Features.Reservations.Commands.UpdateReservations;

namespace Parque.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InscriptionsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllnscriptionsQuery()));   
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetByIdInscriptionsQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateInscriptionsCommand entity)
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
            return Ok(await Mediator.Send(new DeleteInscriptionsCommand { Id = id }));  
        }

    }
}
