using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteMainteneace.Application.UseCases.Locale;
using TesteMainteneace.Application.UseCases.Locale.CreateLocale;
using TesteMainteneace.Application.UseCases.Locale.GetAllLocale;
using TesteMainteneace.Application.UseCases.Locale.GetByName;

namespace TestMainteneace.Api.Controllers
{
    [ApiController]
    [Route("v1/api")]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Create a new Location of mainteneace
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// 
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CreateLocaleResponse>> CreateLocation(CreateLocaleRequest request,
                                                                                CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Created("", result);

        }
        /// <summary>
        /// Get all locations registers
        /// </summary>
        /// 
        /// <param name="cancellationToken"></param>
        /// 
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<LocaleDefault>>> GetList(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllLocaleRequest(), cancellationToken);
            return Ok(result);
        }
        /// <summary>
        /// Get location by name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cancellationToken"></param>
        /// 
        /// <returns></returns>
        [HttpGet("{name}")]
        public async Task<ActionResult<LocaleDefault>> GetByName(string name, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetByNameRequest(name), cancellationToken);

            return Ok(result);
        }
    }
}
