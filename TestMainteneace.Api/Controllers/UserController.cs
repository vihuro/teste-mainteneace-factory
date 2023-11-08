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
            try
            {
                var result = await _mediator.Send(request, cancellationToken);

                /*var validator = new CreateUserValidator();
                var validationResult = await validator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                    
                }*/

                return Created("", result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<List<UserResponse>>> UpdateList(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new GetUserApiAuthForThisServiceRequest(), cancellationToken);

                return Created("", result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
