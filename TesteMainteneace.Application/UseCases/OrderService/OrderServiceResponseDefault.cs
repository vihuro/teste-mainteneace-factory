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
    }

}
