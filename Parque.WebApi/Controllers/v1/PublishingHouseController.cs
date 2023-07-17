using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Parque.Application.Features.PublishingHouses.Commands.CreatePublishingHouses;
using Parque.Application.Features.PublishingHouses.Commands.DeletePublishingHouses;
using Parque.Application.Features.PublishingHouses.Commands.UpdatePublishingHouses;
using Parque.Application.Features.PublishingHouses.Queries.GetAllPublishingHouses;
using Parque.Application.Features.PublishingHouses.Queries.GetByIdPublishingHouses;

namespace Parque.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PublishingHouseController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPublishingHousesQuery()));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetByIdPublishingHousesQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePublishingHousesCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdatePublishingHousesCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePublishingHousesCommand { Id = id })); 
        }
    }
}
