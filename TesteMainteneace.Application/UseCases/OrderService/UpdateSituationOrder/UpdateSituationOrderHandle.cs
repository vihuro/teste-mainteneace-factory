

using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Entities.Order.Enun;
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

        public UpdateSituationOrderHandle(IUnitOfWork unitOfWork, 
                                            IOrderServiceRepository orderRepository, 
                                            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderServiceResponseDefault> Handle(UpdateSituationOrderRequest request,
                                                                CancellationToken cancellationToken)
        {
            var entity = await _orderRepository.GetById(request.IdOrderService, cancellationToken);

            entity.DateUpdated = DateTime.UtcNow;
            entity.Situacion = ValidateSituation(request.TypeSituation);

            _orderRepository.Updated(entity);

            await _unitOfWork.Commit(cancellationToken);

            entity = await _orderRepository.GetByIdComplete(request.IdOrderService, cancellationToken);

            var result = _mapper.Map<OrderServiceResponseDefault>(entity);

            return result;

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
