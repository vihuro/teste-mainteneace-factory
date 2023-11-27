using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Entities.Order;
using TesteMainteneace.Domain.Entities.OrderFlow.UserFlow;
using TesteMainteneace.Domain.Entities.StatusOrder;
using TesteMainteneace.Domain.Interfaces.Flow;
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
        private readonly IFlowRepository _flowRepository;

        public CreateOrderServiceHandle(IMapper mapper, IOrderServiceRepository orderServiceRepository,
                                        IUnitOfWork unitOfWork, IFlowRepository flowRepository)
        {
            _mapper = mapper;
            _orderServiceRepository = orderServiceRepository;
            _unitOfWork = unitOfWork;
            _flowRepository = flowRepository;
        }

        public async Task<OrderServiceResponseDefault> Handle(CreateOrderServiceRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<OrderServiceEntity>(request);

            var listFlow = await _flowRepository.GetList(cancellationToken);

            var listEntity = new List<FlowOrderServiceEntity>();

            foreach (var item in listFlow)
            {
                var flow = new FlowOrderServiceEntity();
                flow.FlowId = item.Id;
                if(item.Id == 1)
                {
                    flow.InitialUserFlow = new InitialUserFlow
                    {
                        UserInitialId = entity.UserCreatedId,
                        DateCreateded = DateTime.UtcNow,
                    };
                }
                listEntity.Add(flow);
            }

            entity.ListFlow = listEntity;

            _orderServiceRepository.Create(entity);

            await _unitOfWork.Commit(cancellationToken);

            entity = await _orderServiceRepository.GetByIdComplete(entity.Id, cancellationToken);

            return _mapper.Map<OrderServiceResponseDefault>(entity);


        }
    }
}
