using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Interfaces.Order;

namespace TesteMainteneace.Application.UseCases.OrderService.GetById
{
    public class GetByIdHandle :
        IRequestHandler<GetByIdRequest, OrderServiceResponseDefault>
    {
        private readonly IOrderServiceRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdHandle(IOrderServiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderServiceResponseDefault> Handle(GetByIdRequest request, 
                                                                CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdComplete(request.Id, cancellationToken);

            return _mapper.Map<OrderServiceResponseDefault>(result);
        }
    }
}
