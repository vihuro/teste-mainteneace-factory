using MediatR;

namespace TesteMainteneace.Application.UseCases.Locale.CreateLocale
{
    public sealed record CreateLocaleRequest(string Name, Guid UserId) : IRequest<CreateLocaleResponse>;
}
