using AutoMapper;
using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Application.UseCases.Locale.GetAllLocale
{
    public class GetAllLocaleMapper : Profile
    {
        public GetAllLocaleMapper() 
        {
            CreateMap<LocalExecutation, LocaleDefault>();
        }
    }
}
