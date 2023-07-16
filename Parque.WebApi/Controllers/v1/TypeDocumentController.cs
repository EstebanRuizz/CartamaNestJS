using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parque.Application.Features.TypeDocuments.Commands.CreateTypeDocument;

namespace Parque.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TypeDocumentController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateTypeDocumentCommand entity)
        {
            return Ok(await Mediator.Send(entity)); 
        }
    }
}
