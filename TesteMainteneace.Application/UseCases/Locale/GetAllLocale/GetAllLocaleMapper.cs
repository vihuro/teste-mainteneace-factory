using AutoMapper;
using TesteMainteneace.Application.UseCases.User;
using TesteMainteneace.Domain.Entities.Location;

namespace TesteMainteneace.Application.UseCases.Locale.GetAllLocale
{
    public class GetAllLocaleMapper : Profile
    {
        public GetAllLocaleMapper() 
        {
            CreateMap<LocalExecutationEntity, LocaleDefault>()
                .ForMember(x => x.Name, map => map.MapFrom(src => src.Local));
        }
    }
}
