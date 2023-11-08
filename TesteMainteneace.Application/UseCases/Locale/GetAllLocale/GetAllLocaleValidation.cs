using FluentValidation;

namespace TesteMainteneace.Application.UseCases.Locale.GetAllLocale
{
    public sealed class GetAllLocaleValidation : AbstractValidator<List<GetAllLocaleRequest>>
    {
        public GetAllLocaleValidation() { }
    }
}
