using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parque.Application.Features.Publications.Commands.CreatePublication;
using Parque.Application.Features.Publications.Queries.GetAllPublications;

namespace Parque.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PublicationsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllPublications()
        {
            return Ok(await Mediator.Send(new GetAllPublicationsQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePublicationCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }
    }
}
