using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Entities.Order;
using TesteMainteneace.Domain.Interfaces.Order;
using TesteMainteneace.Domain.Interfaces.System;

namespace TesteMainteneace.Application.UseCases.OrderService.CreateOrderService
{
    public class CreateOrderServiceHandle :
        IRequestHandler<CreateOrderServiceRequest, OrderServiceResponseDefault>
    {
        private readonly IMapper _mapper;
        private readonly IOrderServiceRepository _orderServiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderServiceHandle(IMapper mapper, IOrderServiceRepository orderServiceRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _orderServiceRepository = orderServiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderServiceResponseDefault> Handle(CreateOrderServiceRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<OrderServiceEntity>(request);

            _orderServiceRepository.Create(entity);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<OrderServiceResponseDefault>(entity);


        }
    }
}
