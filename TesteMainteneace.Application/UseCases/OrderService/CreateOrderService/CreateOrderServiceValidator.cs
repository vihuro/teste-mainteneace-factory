using FluentValidation;


namespace TesteMainteneace.Application.UseCases.OrderService.CreateOrderService
{
    public class CreateOrderServiceValidator : AbstractValidator<CreateOrderServiceRequest>
    {
        public CreateOrderServiceValidator()
        {
            RuleFor(x => x.UserCreatedId)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.LocationMainteneaceId)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.TypeService)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Priority)
                .NotEmpty()
                .NotNull();
        }
    }
}
