using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Interfaces.Location;

namespace TesteMainteneace.Application.UseCases.Locale.GetAllLocale
{
    public class GetAllLocaleHandle :
        IRequestHandler<GetAllLocaleRequest, List<LocaleDefault>>
    {
        private readonly ILocaleExecutationRepository _locationRepository;
        private readonly IMapper _mapper;

        public GetAllLocaleHandle(ILocaleExecutationRepository locationRepository, 
                                  IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<List<LocaleDefault>> Handle(GetAllLocaleRequest request, 
                                                        CancellationToken cancellationToken)
        {
            var listLocations = await _locationRepository
                                        .GetWithUser(cancellationToken);

            return _mapper.Map<List<LocaleDefault>>(listLocations);
        }
    }
}
