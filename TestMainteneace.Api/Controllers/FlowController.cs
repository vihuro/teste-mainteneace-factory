using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteMainteneace.Application.UseCases.Flow;
using TesteMainteneace.Application.UseCases.Flow.GetListFlow;

namespace TestMainteneace.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class FlowController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FlowController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get list of the Flows
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<FlowResponseDefault>>> GetList(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetListFlowRequest(), cancellationToken);

            return Ok(result);
        }
    }
}
