

using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Entities.Order.Enun;
using TesteMainteneace.Domain.Interfaces.Flow;
using TesteMainteneace.Domain.Interfaces.Order;
using TesteMainteneace.Domain.Interfaces.System;

namespace TesteMainteneace.Application.UseCases.OrderService.UpdateSituationOrder
{
    public class UpdateSituationOrderHandle :
        IRequestHandler<UpdateSituationOrderRequest, OrderServiceResponseDefault>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderServiceRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IFlowInOrderServiceRepository _flowInOrderServiceRepository;

        public UpdateSituationOrderHandle(IUnitOfWork unitOfWork,
                                            IOrderServiceRepository orderRepository,
                                            IMapper mapper,
                                            IFlowInOrderServiceRepository flowRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _mapper = mapper;
            _flowInOrderServiceRepository = flowRepository;
        }

        public async Task<OrderServiceResponseDefault> Handle(UpdateSituationOrderRequest request,
                                                                CancellationToken cancellationToken)
        {
            var entity = await _orderRepository.GetById(request.IdOrderService, cancellationToken);

            var situation = ValidateSituation(request.TypeSituation);

            entity.DateUpdated = DateTime.UtcNow;
            entity.Situacion = situation;

            _orderRepository.Updated(entity);

            await HandleFlowInOrderService(situation, request.FlowId, request.IdOrderService, request.UserId);

            await _unitOfWork.Commit(cancellationToken);

            entity = await _orderRepository.GetByIdComplete(request.IdOrderService, cancellationToken);

            var result = _mapper.Map<OrderServiceResponseDefault>(entity);

            return result;

        }
        private async Task HandleFlowInOrderService(ESituationOrderService situation,
                                                    int flowId, int orderServiceId, Guid userId)
        {
            switch (situation)
            {
                case ESituationOrderService.WAITING_ATRIBUIATION:
                    await _flowInOrderServiceRepository.ValidateFlow(flowId, orderServiceId, userId);
                    break;
                case ESituationOrderService.ORDER_INVALID:
                    await _flowInOrderServiceRepository.ValidateFlow(flowId + 1, orderServiceId, userId);
                    break;
                case ESituationOrderService.WAITING_MAINTENEACE:
                    await _flowInOrderServiceRepository.ValidateFlow(flowId, orderServiceId, userId);
                    await _flowInOrderServiceRepository.ValidateFlow(flowId + 2, orderServiceId, userId);

                    break;
                case ESituationOrderService.IN_MAINTENEACE:
                    await _flowInOrderServiceRepository.ValidateFlow(flowId, orderServiceId, userId);
                    await _flowInOrderServiceRepository.ValidateFlow(flowId + 1, orderServiceId, userId);
                    await _flowInOrderServiceRepository.ValidateFlow(flowId + 1, orderServiceId, userId);
                    break;
                case ESituationOrderService.WAITING_PARTS:
                    await _flowInOrderServiceRepository.ValidateFlow(flowId, orderServiceId, userId);
                    break;
                case ESituationOrderService.WAITING_AUTORIZATION_PARTS:
                    await _flowInOrderServiceRepository.ValidateFlow(flowId, orderServiceId, userId);
                    break;
                case ESituationOrderService.MAINTENEACE_END:
                    await _flowInOrderServiceRepository.ValidateFlow(flowId, orderServiceId, userId);
                    await _flowInOrderServiceRepository.ValidateFlow(flowId, orderServiceId, userId);
                    break;
                case ESituationOrderService.MAINTENEACE_INVALID:
                    await _flowInOrderServiceRepository.ValidateFlow(flowId, orderServiceId, userId);
                    break;
                case ESituationOrderService.ORDER_END:
                    await _flowInOrderServiceRepository.ValidateFlow(flowId, orderServiceId, userId);
                    await _flowInOrderServiceRepository.ValidateFlow(flowId, orderServiceId, userId);
                    break;
                default:
                    await _flowInOrderServiceRepository.ValidateFlow(flowId, orderServiceId, userId);
                    break;

            }
        }

        private static ESituationOrderService ValidateSituation(int typeSituation)
        {
            switch (typeSituation)
            {
                case 1:
                    return ESituationOrderService.ORDER_INVALID;
                case 2:
                    return ESituationOrderService.WAITING_MAINTENEACE;
                case 3:
                    return ESituationOrderService.IN_MAINTENEACE;
                case 4:
                    return ESituationOrderService.WAITING_PARTS;
                case 5:
                    return ESituationOrderService.WAITING_AUTORIZATION_PARTS;
                case 6:
                    return ESituationOrderService.MAINTENEACE_END;
                case 7:
                    return ESituationOrderService.MAINTENEACE_INVALID;
                case 8:
                    return ESituationOrderService.ORDER_END;
                default:
                    return ESituationOrderService.WAITING_ATRIBUIATION;
            }
        }
    }
}
