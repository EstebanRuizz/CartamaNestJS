using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parque.Application.Features.Roles.Queries.GetById;
using Parque.Application.Features.TypeAliances.Commands.DeleteTypeAliance;
using Parque.Application.Features.TypePublications.Commands.CreateTypePublications;
using Parque.Application.Features.TypePublications.Commands.DeleteTypePublications;
using Parque.Application.Features.TypePublications.Commands.UpdateTypePublications;
using Parque.Application.Features.TypePublications.Queries.GetAllTypePublications;
using Parque.Application.Features.TypePublications.Queries.GetByIdTypePublications;

namespace Parque.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TypePublicationsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTypePublicationsQuery()));  
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetByIdTypePublicationsQuery { Id = id }));
        }

        [HttpPost] 
        public async Task<IActionResult> Post(CreateTypePublicationsCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateTypePublicationsCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTypePublicationsCommand { Id = id }));
        }
    }
}
