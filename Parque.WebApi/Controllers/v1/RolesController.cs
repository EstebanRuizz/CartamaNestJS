    using Microsoft.AspNetCore.Mvc;
using Parque.Application.Features.Roles.Commands.CreateRoles;
using Parque.Application.Features.Roles.Commands.DeleteRoles;
using Parque.Application.Features.Roles.Commands.UpdateRoles;
using Parque.Application.Features.Roles.Queries.GetAllRoles;
using Parque.Application.Features.Roles.Queries.GetById;

namespace Parque.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RolesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllRolesQuery()));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetRoleByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateRolesCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateRolesCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteRolesCommand { Id = id }));
        }
    }
}
