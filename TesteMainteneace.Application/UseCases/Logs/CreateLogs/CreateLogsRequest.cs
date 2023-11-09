using MediatR;

namespace TesteMainteneace.Application.UseCases.Logs.CreateLogs
{
    public sealed record CreateLogsRequest(Guid Id, string LogRef, List<string> Message) : IRequest<CreateLogsResponse>;
}
