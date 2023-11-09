using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Interfaces;

namespace TesteMainteneace.Application.UseCases.Logs.GetLogs
{
    public class GetLogsHandle :
                IRequestHandler<GetLogsRequest, List<GetLogsResponse>>
    {
        private readonly ILogsRepository _logsRepository;
        private readonly IMapper _mapper;

        public GetLogsHandle(ILogsRepository logsRepository, IMapper mapper)
        {
            _logsRepository = logsRepository;
            _mapper = mapper;
        }

        public async Task<List<GetLogsResponse>> Handle(GetLogsRequest request, CancellationToken cancellationToken)
        {
            var list = await _logsRepository.GetAll(cancellationToken);

            return _mapper.Map<List<GetLogsResponse>>(list);
        }
    }
}
