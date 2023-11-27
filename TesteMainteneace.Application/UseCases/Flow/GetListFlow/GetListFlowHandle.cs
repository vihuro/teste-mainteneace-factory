using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Interfaces.Flow;

namespace TesteMainteneace.Application.UseCases.Flow.GetListFlow
{
    public class GetListFlowHandle :
        IRequestHandler<GetListFlowRequest, List<FlowResponseDefault>>
    {
        private readonly IFlowRepository _repository;
        private readonly IMapper _mapper;

        public GetListFlowHandle(IFlowRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<FlowResponseDefault>> Handle(GetListFlowRequest request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetList(cancellationToken);

            return _mapper.Map<List<FlowResponseDefault>>(list);
        }
    }
}
