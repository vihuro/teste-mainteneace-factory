using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteMainteneace.Application.UseCases.Reports.Storage.GetStorageRadar;

namespace TestMainteneace.Api.Controllers
{
    [ApiController]
    [Route("api/v1/reports-radar/storage")]
    [Produces("application/json")]
    public class ReportsRadarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsRadarController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Search all items in Reports of the Radar
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// 
        [HttpGet]
        public async Task<ActionResult<List<GetStorageRadarResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetStorageRadarRequest(), cancellationToken);

            return Ok(result);
        }
    }
}
