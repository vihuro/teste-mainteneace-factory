using AutoMapper;
using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Application.UseCases.UserAuthApiExternal.GetQueryUserApiAuth
{
    public class GetQueryUserApiAuthMapper : Profile
    {
        public GetQueryUserApiAuthMapper()
        {
            CreateMap<UserAuthApi, GetQueryUserApiAuthResponse>();
        }
    }
}
