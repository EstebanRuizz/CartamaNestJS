using Microsoft.AspNetCore.Mvc;
using Parque.Application.Features.Aliances.Querys.GetAllAliances;

namespace Parque.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AliancesController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllAliancesQuery()));
        }

    }
}
