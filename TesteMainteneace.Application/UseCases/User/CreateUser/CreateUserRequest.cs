using MediatR;

namespace TesteMainteneace.Application.UseCases.User.CreateUser
{
    public sealed record CreateUserRequest(string UserName, string Name, bool Actived) : IRequest<UserResponse>;

}
