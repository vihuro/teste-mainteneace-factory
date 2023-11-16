using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Interfaces.Location;
using TesteMainteneace.Domain.Interfaces.System;

namespace TesteMainteneace.Application.UseCases.Locale.GetByName
{
    public class GetByNameHandle :
        IRequestHandler<GetByNameRequest, LocaleDefault>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILocaleExecutationRepository _localeRepository;
        private readonly IMapper _mapper;

        public GetByNameHandle(IUnitOfWork unitOfWork, ILocaleExecutationRepository localeRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _localeRepository = localeRepository;
            _mapper = mapper;
        }

        public async Task<LocaleDefault> Handle(GetByNameRequest request, CancellationToken cancellationToken)
        {
            var result = await _localeRepository.GetByNameLocale(request.Name, cancellationToken);

            return _mapper.Map<LocaleDefault>(result);
        }
    }
}
