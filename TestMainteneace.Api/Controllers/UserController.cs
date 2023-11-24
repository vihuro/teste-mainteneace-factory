using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteMainteneace.Application.UseCases.User;
using TesteMainteneace.Application.UseCases.UserAuthApiExternal.GetUserApiAuthForThisService;

namespace TestMainteneace.Api.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Search for update users for this database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// 
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<List<UserResponse>>> UpdateList(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetUserApiAuthForThisServiceRequest(), cancellationToken);

            return Created("", result);

        }
    }
}
