using AutoMapper;
using TesteMainteneace.Domain.Entities.Order;
using TesteMainteneace.Domain.Entities.Order.Enun;

namespace TesteMainteneace.Application.UseCases.OrderService.CreateOrderService
{
    public class CreateOrderServiceMapper : Profile
    {
        public CreateOrderServiceMapper()
        {
            CreateMap<CreateOrderServiceRequest, OrderServiceEntity>()
                .ForMember(x => x.Situacion, map => map.MapFrom(src => ESituationOrderService.WAITING_ATRIBUIATION))
                .ForMember(x => x.Priority, map => map.MapFrom(src => src.Priority))
                .ForMember(x => x.SuggestedMainteneaceDate, map => map.MapFrom(src => src.SuggestdMainteneaceDate))
                .ForMember(x => x.LocationMainteneaceId, map => map.MapFrom(src => src.LocationMainteneaceId))
                .ForMember(x => x.Type, map => map.MapFrom(src => src.TypeService))
                .ForMember(x => x.Category, map => map.MapFrom(src => src.Category));
        }
    }
}
