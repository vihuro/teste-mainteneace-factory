using MediatR;

namespace TesteMainteneace.Application.UseCases.Logs.CreateLogs
{
    public sealed record CreateLogsRequest(Guid Id, string ClassError, string LineError, string LogRef, List<string> Erros) : IRequest<CreateLogsResponse>;
}
