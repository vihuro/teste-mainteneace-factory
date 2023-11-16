
using MediatR;

namespace TesteMainteneace.Application.UseCases.Locale.GetByName
{
    public sealed record GetByNameRequest(string Name) : IRequest<LocaleDefault>;
}
