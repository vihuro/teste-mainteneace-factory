using MediatR;


namespace TesteMainteneace.Application.UseCases.OrderService.GetAllOrderService
{
    public sealed record GetAllOrderServiceRequest : IRequest<List<OrderServiceResponseDefault>>;
}
