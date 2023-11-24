using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteMainteneace.Application.UseCases.StorageParts;
using TesteMainteneace.Application.UseCases.StorageParts.GetAllParts;
using TesteMainteneace.Application.UseCases.StorageParts.GetPartsNotRegistered;
using TesteMainteneace.Application.UseCases.StorageParts.UpdateParts;

namespace TestMainteneace.Api.Controllers
{
    [ApiController]
    [Route("api/v1/storage/parts")]
    [Produces("application/json")]
    public class StoragePartsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoragePartsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get all parts registereds
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// 
        [HttpGet]
        public async Task<ActionResult<List<PartsResponseDefault>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllPartsRequest(), cancellationToken);

            return Ok(result);
        }
        /// <summary>
        /// Get parts not registered
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// 
        [HttpGet("not-registered")]
        public async Task<ActionResult<List<PartsResponseDefault>>> GetNotRegistered(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetPartsNotRegisteredRequest(), cancellationToken);

            return Ok(result);
        }
        /// <summary>
        /// Update parts in database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// 
        [HttpPut]
        public async Task<ActionResult<List<PartsResponseDefault>>> Update(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new UpdatePartsRequest(), cancellationToken);
            if (result == null) return NotFound("Not item for update in this database");

            return Created("", result);
        }
    }
}
