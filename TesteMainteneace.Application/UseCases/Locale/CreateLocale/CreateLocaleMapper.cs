using AutoMapper;
using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Application.UseCases.Locale.CreateLocale
{
    public class CreateLocaleMapper : Profile
    {
        public CreateLocaleMapper()
        {
            CreateMap<CreateLocaleRequest, LocalExecutation>()
                .ForMember(x => x.Local, map => map.MapFrom(src => src.Name));
            CreateMap<LocalExecutation, CreateLocaleResponse>()
                .ForMember(x => x.Name, map => map.MapFrom(src => src.Local));
        }

    }
}
