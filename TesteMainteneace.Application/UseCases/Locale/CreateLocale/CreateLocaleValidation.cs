using FluentValidation;
using TesteMainteneace.Domain.Interfaces;

namespace TesteMainteneace.Application.UseCases.Locale.CreateLocale
{
    public sealed class CreateLocaleValidation : AbstractValidator<CreateLocaleRequest>
    {

        private readonly ILocaleExecutationRepository _localExecutationRepository;
        public CreateLocaleValidation(ILocaleExecutationRepository localeExecutationRepository)
        {
            _localExecutationRepository = localeExecutationRepository;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x)
                .MustAsync(ValidateName)
                .WithMessage("Location already registered!");
        }

        private async Task<bool> ValidateName(CreateLocaleRequest request,
                                                CancellationToken cancellationToken)
        {
            var item = await _localExecutationRepository
                        .GetByNameLocale(request.Name.ToUpper(), 
                                          cancellationToken);

            if (item == null) return true;

            return false;
        }
    }
}
