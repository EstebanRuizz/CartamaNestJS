using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parque.Application.Features.TypeDocuments.Commands.CreateTypeDocument;
using Parque.Application.Features.TypeDocuments.Commands.DeleteTypeDocument;
using Parque.Application.Features.TypeDocuments.Commands.UpdateTypeDocument;
using Parque.Application.Features.TypeDocuments.Queries.GetAllTypeDocument;
using Parque.Application.Features.TypeDocuments.Queries.GetByIdTypeDocument;
using Parque.Application.Features.TypePublications.Commands.DeleteTypePublications;

namespace Parque.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TypeDocumentController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTypeDocumentQuery()));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetByIdTypeDocumentQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateTypeDocumentCommand entity)
        {
            return Ok(await Mediator.Send(entity)); 
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateTypeDocumentCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTypeDocumentCommand { Id = id }));
        }
    }
}
