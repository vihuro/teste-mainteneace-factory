using AutoMapper;
using TesteMainteneace.Domain.Entities.Order;
using static TesteMainteneace.Application.UseCases.OrderService.ValidateEnunInOrderService;

namespace TesteMainteneace.Application.UseCases.OrderService.GetAllOrderService
{
    public class GetAllOrderServiceMapper : Profile
    {
        public GetAllOrderServiceMapper()
        {
            CreateMap<OrderServiceEntity, OrderServiceResponseDefault>()
                .ForMember(x => x.Situation, map => map.MapFrom(src => ValidateSituacion(src.Situacion)))
                .ForMember(x => x.Priority, map => map.MapFrom(src => ValidatePriority(src.Priority)))
                .ForMember(x => x.LocaleManinteace, map => map.MapFrom(src => src.LocationMainteneace.Local))
                .ForMember(x => x.TypeService, map => map.MapFrom(src => ValidateTypeMainteneace(src.EType)))
                .ForMember(x => x.UserRegisterd, map => map.MapFrom(src => new UserRegistered
                {
                    Actived = src.UserCreated.Actived,
                    Id = src.UserCreated.Id,
                    Name = src.UserCreated.Name,
                    UserName = src.UserCreated.UserName
                }));
        }
    }
}
