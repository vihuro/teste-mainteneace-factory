namespace TesteMainteneace.Application.UseCases.User
{
    public sealed record UserResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public bool Actived { get; set; }
    }
}
