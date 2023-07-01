using Microsoft.AspNetCore.Mvc;
using Parque.Application.Features.Enviromments.Commands.Create;
using Parque.Application.Features.Enviromments.Commands.Delete;
using Parque.Application.Features.Enviromments.Commands.Update;
using Parque.Application.Features.Enviromments.Queries.GetAll;
using Parque.Application.Features.Enviromments.Queries.GetByIdAsync;

namespace Parque.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EnviromentController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllEnviromentsQuery()));
        }
        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetByIdEnviromentQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateEnviromentCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateEnviromentCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id) => Ok(await Mediator.Send(new DeleteEnviromentCommand { Id = id }));

    }
}
