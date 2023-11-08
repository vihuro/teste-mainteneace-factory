using AutoMapper;
using TesteMainteneace.Application.UseCases.User;
using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Application.UseCases.UserAuthApiExternal.GetUserApiAuthForThisService
{
    public class GetUserApiAuthForThisServiceMapper : Profile
    {
        public GetUserApiAuthForThisServiceMapper()
        {
            CreateMap<UserAuthApi, UserAuth>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.UsuarioId))
                .ForMember(x => x.UserName, map => map.MapFrom(src => src.Apelido))
                .ForMember(x => x.Name, map => map.MapFrom(src => src.Nome))
                .ForMember(x => x.Actived, map => map.MapFrom(src => src.Ativo));
            CreateMap<UserAuth, UserResponse>();
        }
    }
}
