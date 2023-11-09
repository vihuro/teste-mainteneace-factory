using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Entities.Location;
using TesteMainteneace.Domain.Interfaces.Location;
using TesteMainteneace.Domain.Interfaces.System;

namespace TesteMainteneace.Application.UseCases.Locale.CreateLocale
{
    public class CreateLocaleHandle :
        IRequestHandler<CreateLocaleRequest, CreateLocaleResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILocaleExecutationRepository _locationRepository;
        private readonly IMapper _mapper;

        public CreateLocaleHandle(IUnitOfWork unitOfWork, 
                                    ILocaleExecutationRepository locationRepository, 
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<CreateLocaleResponse> Handle(CreateLocaleRequest request, 
                                                        CancellationToken cancellationToken)
        {
            var location = _mapper.Map<LocalExecutationEntity>(request);
            _locationRepository.Create(location);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateLocaleResponse>(location);
        }
    }
}
