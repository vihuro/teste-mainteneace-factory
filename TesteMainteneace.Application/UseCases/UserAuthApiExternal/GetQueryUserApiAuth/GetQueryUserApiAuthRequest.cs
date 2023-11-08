using MediatR;

namespace TesteMainteneace.Application.UseCases.UserAuthApiExternal.GetQueryUserApiAuth
{
    public sealed record GetQueryUserApiAuthRequest : IRequest<List<GetQueryUserApiAuthResponse>>;
}
