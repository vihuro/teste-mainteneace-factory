namespace TesteMainteneace.Application.UseCases.OrderService
{
    public sealed record class OrderServiceResponseDefault
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LocaleManinteace { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Situation { get; set; }
        public string Priority { get; set; }
        public string TypeService { get; set; }
        public UserRegistered UserRegisterd { get; set; }
    }
    public class UserRegistered
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public bool Actived { get; set; }
    }

}
