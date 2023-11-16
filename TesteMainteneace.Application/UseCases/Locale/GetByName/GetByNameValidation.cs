using FluentValidation;

namespace TesteMainteneace.Application.UseCases.Locale.GetByName
{
    public class GetByNameValidation : AbstractValidator<GetByNameRequest>
    {
        public GetByNameValidation() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
