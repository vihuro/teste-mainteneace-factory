using FluentValidation;

namespace TesteMainteneace.Application.UseCases.Logs.CreateLogs
{
    public class CreateLogsValidation : AbstractValidator<CreateLogsRequest>
    {
        public CreateLogsValidation() { }
    }
}
