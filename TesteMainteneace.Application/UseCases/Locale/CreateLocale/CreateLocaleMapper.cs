using AutoMapper;
using TesteMainteneace.Domain.Entities.Location;

namespace TesteMainteneace.Application.UseCases.Locale.CreateLocale
{
    public class CreateLocaleMapper : Profile
    {
        public CreateLocaleMapper()
        {
            CreateMap<CreateLocaleRequest, LocalExecutationEntity>()
                .ForMember(x => x.Local, map => map.MapFrom(src => src.Name.ToUpper()))
                .ForMember(x => x.UserAuthId, map => map.MapFrom(src => src.UserId));

            CreateMap<LocalExecutationEntity, CreateLocaleResponse>()
                .ForMember(x => x.Name, map => map.MapFrom(src => src.Local));
        }

    }
}
