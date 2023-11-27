using AutoMapper;
using TesteMainteneace.Application.UseCases.User;
using TesteMainteneace.Domain.Entities.Order;
using TesteMainteneace.Domain.Entities.OrderFlow.UserFlow;
using TesteMainteneace.Domain.Entities.StatusOrder;
using static TesteMainteneace.Application.UseCases.OrderService.ValidateEnunInOrderService;


namespace TesteMainteneace.Application.UseCases.OrderService
{
    public class OrderServiceResponseDefaultMapper : Profile
    {
        public OrderServiceResponseDefaultMapper()
        {
            CreateMap<OrderServiceEntity, OrderServiceResponseDefault>()
                .ForMember(x => x.Situation, map => map.MapFrom(src => ValidateSituacion(src.Situacion)))
                .ForMember(x => x.Priority, map => map.MapFrom(src => ValidatePriority(src.Priority)))
                .ForMember(x => x.LocaleManinteace, map => map.MapFrom(src => src.LocationMainteneace.Local))
                .ForMember(x => x.TypeService, map => map.MapFrom(src => ValidateTypeMainteneace(src.Type)))
                .ForMember(x => x.SuggestdMainteneaceDate, map => map.MapFrom(src => src.SuggestedMainteneaceDate))
                .ForMember(x => x.Category, map => map.MapFrom(src => ValidateCategoryService(src.Category)))
                .ForPath(x => x.UserRegisterd, map => map.MapFrom(src => new UserResponse
                {
                    Name = src.UserCreated.Name,
                    Actived = src.UserCreated.Actived,
                    Id = src.UserCreatedId,
                    UserName = src.UserCreated.UserName
                }))
                .ForPath(x => x.FlowList, map => map.MapFrom(src => src.ListFlow.Select(flow => new FlowInOrderService
                {
                    UserInit = ValidateInitialUser(flow.InitialUserFlow),
                    TypeFlow = flow.Flow.TypeFlow,
                    Id = flow.Id,
                    UserEnd = ValidateEndUserFlow(flow.EndUserFlow),
                    Observation = flow.Description,
                })));;
        }
        private static UserInFlow ValidateInitialUser(InitialUserFlow initialUser)
        {
            if (initialUser == null) return null;

            return new UserInFlow
            {
                Id = initialUser.UserInitial.Id,
                Name = initialUser.UserInitial.Name,
                UserName = initialUser.UserInitial.UserName,
                DateTime = initialUser.DateCreateded
            };
        }
        private static UserInFlow ValidateEndUserFlow(EndUserFlow endUser)
        {
            if (endUser == null) return null;

            return new UserInFlow
            {
                Id = endUser.UserEndId,
                Name = endUser.UserEnd.Name,
                UserName = endUser.UserEnd.UserName,
                DateTime = endUser.DateEnd
            };
        }
    }
}
