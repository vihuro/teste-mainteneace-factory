using MediatR;

namespace TesteMainteneace.Application.UseCases.Logs.GetLogs
{
    public sealed record GetLogsRequest : IRequest<List<GetLogsResponse>>;
}
