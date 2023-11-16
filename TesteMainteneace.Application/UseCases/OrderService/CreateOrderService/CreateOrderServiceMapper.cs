using AutoMapper;
using TesteMainteneace.Domain.Entities.Order;
using TesteMainteneace.Domain.Entities.Order.Enun;
using static TesteMainteneace.Application.UseCases.OrderService.ValidateEnunInOrderService;

namespace TesteMainteneace.Application.UseCases.OrderService.CreateOrderService
{
    public class CreateOrderServiceMapper : Profile
    {
        public CreateOrderServiceMapper()
        {
            CreateMap<CreateOrderServiceRequest, OrderServiceEntity>()
                .ForMember(x => x.Situacion, map => map.MapFrom(src => ESituationOrderService.WAITING_ATRIBUIATION))
                .ForMember(x => x.Priority, map => map.MapFrom(src => src.Priority))
                .ForMember(x => x.LocationMainteneaceId, map => map.MapFrom(src => src.LocationMainteneaceId))
                .ForMember(x => x.EType, map => map.MapFrom(src => src.TypeService));

            CreateMap<OrderServiceEntity, OrderServiceResponseDefault>()
                .ForMember(x => x.Situation, map => map.MapFrom(src => ValidateSituacion(src.Situacion)))
                .ForMember(x => x.Priority, map => map.MapFrom(src => ValidatePriority(src.Priority)))
                .ForMember(x => x.LocaleManinteace, map => map.MapFrom(src => src.LocationMainteneace.Local))
                .ForMember(x => x.TypeService, map => map.MapFrom(src => ValidateTypeMainteneace(src.EType)));
        }
    }
}
