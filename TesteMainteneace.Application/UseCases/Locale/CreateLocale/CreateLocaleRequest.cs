using MediatR;

namespace TesteMainteneace.Application.UseCases.Locale.CreateLocale
{
    public sealed record CreateLocaleRequest(string Name) : IRequest<CreateLocaleResponse>;
}
