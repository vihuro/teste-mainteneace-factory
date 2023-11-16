

using MediatR;

namespace TesteMainteneace.Application.UseCases.OrderService.CreateOrderService
{
    public sealed record CreateOrderServiceRequest(string Description, int LocationMainteneaceId, Guid UserCreatedId, int TypeService, int Priority) : IRequest<OrderServiceResponseDefault>;
}
