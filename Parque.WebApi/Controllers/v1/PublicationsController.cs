using Microsoft.AspNetCore.Mvc;
using Parque.Application.Features.Publications.Commands.CreatePublication;
using Parque.Application.Features.Publications.Commands.DeletePublication;
using Parque.Application.Features.Publications.Commands.UpdatePublication;
using Parque.Application.Features.Publications.Queries.GetAllPublications;
using Parque.Application.Features.Publications.Queries.GetByIdPublication;
namespace Parque.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PublicationsController : BaseApiController
    {
         private const int RecordsPerPage = 5;
         private const int InitialPageNumber = 1;

        [HttpGet("limit={limit=10}&offset={offset=1}")]
        public async Task<IActionResult> GetAllPublications(int limit = RecordsPerPage, int offset = InitialPageNumber)
        {
            return Ok(await Mediator.Send(new GetAllPublicationsQuery { Limit = limit, Offset = offset }));
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetByIdPublicationQuery { Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePublicationCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdatePublicationCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePublicationCommand { Id = id }));   
        }
    }
}
