

using AutoMapper;
using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Application.UseCases.User.CreateUser
{
    public class CreateUserMapper : Profile
    {
        public CreateUserMapper() 
        {
            CreateMap<CreateUserRequest, UserAuth>();
            CreateMap<UserAuth, UserResponse>();
        }
    }
}
