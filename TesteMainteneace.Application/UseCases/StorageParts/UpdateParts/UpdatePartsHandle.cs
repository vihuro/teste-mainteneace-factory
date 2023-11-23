using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Interfaces.Storage;
using TesteMainteneace.Domain.Interfaces.System;

namespace TesteMainteneace.Application.UseCases.StorageParts.UpdateParts
{
    public class UpdatePartsHandle :
        IRequestHandler<UpdatePartsRequest, List<PartsResponseDefault>>
    {
        private readonly IMapper _mapper;
        private readonly IStoragePartsRepository _storagePartsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePartsHandle(IMapper mapper, IStoragePartsRepository storagePartsRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _storagePartsRepository = storagePartsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PartsResponseDefault>> Handle(UpdatePartsRequest request, CancellationToken cancellationToken)
        {
            var list = await _storagePartsRepository.GetNotRegistered(cancellationToken);

            if (list.Count > 0)
            {
                var result = await _storagePartsRepository.UpdatePartsInDatabase(list, cancellationToken);

                await _unitOfWork.Commit(cancellationToken);

                return _mapper.Map<List<PartsResponseDefault>>(result);
            }

            return null;

        }
    }
}
