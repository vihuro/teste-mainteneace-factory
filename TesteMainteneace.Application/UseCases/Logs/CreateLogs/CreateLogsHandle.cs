using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Entities;
using TesteMainteneace.Domain.Interfaces;

namespace TesteMainteneace.Application.UseCases.Logs.CreateLogs
{
    public class CreateLogsHandle :
        IRequestHandler<CreateLogsRequest, CreateLogsResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILogsRepository _logsRepository;

        public CreateLogsHandle(IMapper mapper, ILogsRepository logsRepository)
        {
            _mapper = mapper;
            _logsRepository = logsRepository;
        }

        public async Task<CreateLogsResponse> Handle(CreateLogsRequest request, CancellationToken cancellationToken)
        {
            var log = _mapper.Map<LogsEntity>(request);

            await _logsRepository.CreateLog(log);

            return _mapper.Map<CreateLogsResponse>(log);
        }
    }
}
