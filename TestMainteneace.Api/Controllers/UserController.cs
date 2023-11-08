using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteMainteneace.Application.UseCases.User;
using TesteMainteneace.Application.UseCases.User.CreateUser;
using TesteMainteneace.Application.UseCases.UserAuthApiExternal.GetUserApiAuthForThisService;

namespace TestMainteneace.Api.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<UserResponse>> Create(CreateUserRequest request,
                                                              CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Created("", result);

        }
        [HttpPut]
        public async Task<ActionResult<List<UserResponse>>> UpdateList(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetUserApiAuthForThisServiceRequest(), cancellationToken);

            return Created("", result);

        }
    }
}
