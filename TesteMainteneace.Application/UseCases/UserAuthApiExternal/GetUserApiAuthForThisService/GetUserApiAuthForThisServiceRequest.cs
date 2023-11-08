using MediatR;
using TesteMainteneace.Application.UseCases.User;

namespace TesteMainteneace.Application.UseCases.UserAuthApiExternal.GetUserApiAuthForThisService
{
    public sealed record GetUserApiAuthForThisServiceRequest : IRequest<List<UserResponse>>;
}
