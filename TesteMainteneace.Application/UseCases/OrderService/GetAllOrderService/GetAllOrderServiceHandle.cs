using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Interfaces.Order;


namespace TesteMainteneace.Application.UseCases.OrderService.GetAllOrderService
{
    public class GetAllOrderServiceHandle :
        IRequestHandler<GetAllOrderServiceRequest, List<OrderServiceResponseDefault>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderServiceRepository _orderServiceRepository;

        public GetAllOrderServiceHandle(IMapper mapper, IOrderServiceRepository orderServiceRepository)
        {
            _mapper = mapper;
            _orderServiceRepository = orderServiceRepository;
        }

        public async Task<List<OrderServiceResponseDefault>> Handle(GetAllOrderServiceRequest request, CancellationToken cancellationToken)
        {
            var result = await _orderServiceRepository.GetAllOrdersComplete(cancellationToken);

            var mapping = _mapper.Map<List<OrderServiceResponseDefault>>(result);

            return mapping;
        }
    }
}
