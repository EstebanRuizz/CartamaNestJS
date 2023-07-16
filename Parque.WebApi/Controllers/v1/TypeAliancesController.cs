using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parque.Application.Features.TypeAliances.Commands.CreateTypeAliance;
using Parque.Application.Features.TypeAliances.Commands.DeleteTypeAliance;
using Parque.Application.Features.TypeAliances.Commands.UpdateTypeAliance;
using Parque.Application.Features.TypeAliances.Queries.GetAllTypeAliances;
using Parque.Application.Features.TypeAliances.Queries.GetByIdTypeAliances;

namespace Parque.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TypeAliancesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTypeAliancesQuery()));
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetByIdTypeAliancesQuery { Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateTypeAlianceCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }
        
        [HttpPut]
        public async Task<IActionResult> Put(UpdateTypeAlianceCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTypeAlianceCommand { Id = id}));
        }
    }
}
