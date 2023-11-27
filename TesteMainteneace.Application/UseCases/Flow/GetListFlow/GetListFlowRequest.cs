using MediatR;

namespace TesteMainteneace.Application.UseCases.Flow.GetListFlow
{
    public sealed record GetListFlowRequest : IRequest<List<FlowResponseDefault>>;
}
