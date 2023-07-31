using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parque.Application.Features.NewsPapers.Commands.CreateNewsPapers;
using Parque.Application.Features.NewsPapers.Commands.DeleteNewsPaper;
using Parque.Application.Features.NewsPapers.Commands.UpdateNewsPaper;
using Parque.Application.Features.NewsPapers.Queries.GetAllNewsPapers;
using Parque.Application.Features.NewsPapers.Queries.GetByIdNewsPapers;

namespace Parque.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class NewsPaperController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllNewsPapersQuery()));    
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetByIdNewsPapersQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateNewsPapersCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateNewsPaperCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteNewsPaperCommand { Id = id }));
        }

    }
}
