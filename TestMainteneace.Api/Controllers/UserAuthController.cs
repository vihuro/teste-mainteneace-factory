using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteMainteneace.Application.UseCases.UserAuthApiExternal.GetQueryUserApiAuth;

namespace TestMainteneace.Api.Controllers
{
    [ApiController]
    [Route("api/v1/users-auth")]
    public class UserAuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserAuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetQueryUserApiAuthResponse>>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new GetQueryUserApiAuthRequest(),cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
