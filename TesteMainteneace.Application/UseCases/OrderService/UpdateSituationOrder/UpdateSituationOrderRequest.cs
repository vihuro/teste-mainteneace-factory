using MediatR;


namespace TesteMainteneace.Application.UseCases.OrderService.UpdateSituationOrder
{
    public sealed record UpdateSituationOrderRequest(int IdOrderService, int TypeSituation,
                                                    Guid UserId, int FlowId) : IRequest<OrderServiceResponseDefault>;
}
