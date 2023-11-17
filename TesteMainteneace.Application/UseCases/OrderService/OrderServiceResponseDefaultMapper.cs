using AutoMapper;
using TesteMainteneace.Application.UseCases.User;
using TesteMainteneace.Domain.Entities.Order;
using static TesteMainteneace.Application.UseCases.OrderService.ValidateEnunInOrderService;


namespace TesteMainteneace.Application.UseCases.OrderService
{
    public class OrderServiceResponseDefaultMapper : Profile
    {
        public OrderServiceResponseDefaultMapper() 
        {
            CreateMap<OrderServiceEntity,OrderServiceResponseDefault>()
                .ForMember(x => x.Situation, map => map.MapFrom(src => ValidateSituacion(src.Situacion)))
                .ForMember(x => x.Priority, map => map.MapFrom(src => ValidatePriority(src.Priority)))
                .ForMember(x => x.LocaleManinteace, map => map.MapFrom(src => src.LocationMainteneace.Local))
                .ForMember(x => x.TypeService, map => map.MapFrom(src => ValidateTypeMainteneace(src.EType)))
                .ForPath(x => x.UserRegisterd, map => map.MapFrom(src => new UserResponse
                {
                    Name = src.UserCreated.Name,
                    Actived = src.UserCreated.Actived,
                    Id = src.UserCreatedId,
                    UserName = src.UserCreated.UserName
                }));
        }
    }
}
