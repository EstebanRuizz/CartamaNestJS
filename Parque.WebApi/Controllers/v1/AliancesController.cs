using Microsoft.AspNetCore.Mvc;
using Parque.Application.Features.Aliances.Commands.CreateAliances;
using Parque.Application.Features.Aliances.Commands.DeleteAliances;
using Parque.Application.Features.Aliances.Commands.UpdateAliances;
using Parque.Application.Features.Aliances.Querys.GetAllAliances;
using Parque.Application.Features.Aliances.Querys.GetByIdAliances;

namespace Parque.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AliancesController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAliancesParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllAliancesQuery()
            {
                FechaAlianza = filter.FechaAlianza,
                Nombre = filter.Nombre,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TypeAliance = filter.TypeAliance

            }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAliancesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetByIdAliancesQuery()
            {
                Id = id
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateAliancesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteAliancesCommand()
            {
                Id = id
            }));
        }


    }
}
