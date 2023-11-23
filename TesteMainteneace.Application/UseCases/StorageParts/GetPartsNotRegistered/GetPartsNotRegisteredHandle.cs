using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Interfaces.Reports;
using TesteMainteneace.Domain.Interfaces.Storage;

namespace TesteMainteneace.Application.UseCases.StorageParts.GetPartsNotRegistered
{
    public class GetPartsNotRegisteredHandle :
        IRequestHandler<GetPartsNotRegisteredRequest, List<PartsResponseDefault>>
    {
        private readonly IStoragePartsRepository _reportsStorage;
        private readonly IMapper _mapper;

        public GetPartsNotRegisteredHandle(IStoragePartsRepository reportsStorage, IMapper mapper)
        {
            _reportsStorage = reportsStorage;
            _mapper = mapper;
        }

        public async Task<List<PartsResponseDefault>> Handle(GetPartsNotRegisteredRequest request, CancellationToken cancellationToken)
        {
            var list = await _reportsStorage.GetNotRegistered(cancellationToken);

            return _mapper.Map<List<PartsResponseDefault>>(list);
        }
    }
}
