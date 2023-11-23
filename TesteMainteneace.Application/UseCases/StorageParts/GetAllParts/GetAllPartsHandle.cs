using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Interfaces.Storage;

namespace TesteMainteneace.Application.UseCases.StorageParts.GetAllParts
{
    public class GetAllPartsHandle :
        IRequestHandler<GetAllPartsRequest, List<PartsResponseDefault>>
    {
        private readonly IStoragePartsRepository _repository;
        private readonly IMapper _mapper;

        public GetAllPartsHandle(IStoragePartsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PartsResponseDefault>> Handle(GetAllPartsRequest request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetAll(cancellationToken);

            return _mapper.Map<List<PartsResponseDefault>>(item);
        }
    }
}
