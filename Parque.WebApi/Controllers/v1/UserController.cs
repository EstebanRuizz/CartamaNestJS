using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parque.Application.Features.Users.Commands.CreateUsers;
using Parque.Application.Features.Users.Commands.DeleteUsers;
using Parque.Application.Features.Users.Commands.UpdateUsers;
using Parque.Application.Features.Users.Queries.GetAllUsers;
using Parque.Application.Features.Users.Queries.GetByEmailUsers;
using Parque.Application.Features.Users.Queries.GetByIdUsers;

namespace Parque.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetByIdUserQuery { Id = id }));
        }
        
        [HttpGet("email")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            return Ok(await Mediator.Send(new GetByEmailUserQuery { Email = email }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateUserCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand { Id = id }));
        }
    }
}

