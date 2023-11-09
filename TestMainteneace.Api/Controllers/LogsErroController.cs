using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteMainteneace.Application.UseCases.Logs.CreateLogs;
using TesteMainteneace.Application.UseCases.Logs.GetLogs;

namespace TestMainteneace.Api.Controllers
{
    [ApiController]
    [Route("api/v1/logs/error")]
    public class LogsErroController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LogsErroController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetLogsResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var list = await _mediator.Send(new GetLogsRequest(),cancellationToken);

            return Ok(list);
        }
        [HttpPost]
        public async Task<ActionResult<CreateLogsResponse>> CreateLogs(CreateLogsRequest request)
        {
            var item = await _mediator.Send(request);

            return Created("", item);
        }
    }
}
