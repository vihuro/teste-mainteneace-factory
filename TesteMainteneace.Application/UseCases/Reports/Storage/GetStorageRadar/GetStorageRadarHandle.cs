using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Interfaces.Reports;

namespace TesteMainteneace.Application.UseCases.Reports.Storage.GetStorageRadar
{
    public class GetStorageRadarHandle :
        IRequestHandler<GetStorageRadarRequest, List<GetStorageRadarResponse>>
    {
        private readonly IReportsStorage _reportsStorage;
        private readonly IMapper _mapper;

        public GetStorageRadarHandle(IReportsStorage reportsStorage, IMapper mapper)
        {
            _reportsStorage = reportsStorage;
            _mapper = mapper;
        }

        public async Task<List<GetStorageRadarResponse>> Handle(GetStorageRadarRequest request, CancellationToken cancellationToken)
        {
            var list = await _reportsStorage.GetAll();

            return _mapper.Map<List<GetStorageRadarResponse>>(list);
        }
    }
}
