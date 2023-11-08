using FluentValidation;


namespace TesteMainteneace.Application.UseCases.User.CreateUser
{
    public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator() 
        {
            RuleFor(x => x.Actived).NotNull();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
        }
    }
}
