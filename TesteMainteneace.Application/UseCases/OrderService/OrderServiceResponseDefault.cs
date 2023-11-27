using TesteMainteneace.Application.UseCases.Flow;
using TesteMainteneace.Application.UseCases.User;

namespace TesteMainteneace.Application.UseCases.OrderService
{
    public sealed record class OrderServiceResponseDefault
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LocaleManinteace { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime SuggestdMainteneaceDate { get; set; }
        public string Situation { get; set; }
        public string Priority { get; set; }
        public string TypeService { get; set; }
        public string Category { get; set; }
        public UserResponse UserRegisterd { get; set; }
        public List<FlowInOrderService> FlowList { get; set; }
    }
    public class FlowInOrderService
    {
        public int Id { get; set; } 
        public string TypeFlow { get; set; }
        public string Observation { get; set; }
        public UserInFlow UserInit { get; set; }
        public UserInFlow UserEnd { get; set; }
    }

    public class UserInFlow
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
    }

}
