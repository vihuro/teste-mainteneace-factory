using MediatR;

namespace TesteMainteneace.Application.UseCases.Locale.GetAllLocale
{
    public sealed record GetAllLocaleRequest : IRequest<List<LocaleDefault>>;
}
