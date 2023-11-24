using MediatR;


namespace TesteMainteneace.Application.UseCases.OrderService.GetById
{
    public sealed record GetByIdRequest(int Id) : IRequest<OrderServiceResponseDefault>;
}
