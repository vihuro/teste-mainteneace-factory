using TesteMainteneace.Application.UseCases.User;

namespace TesteMainteneace.Application.UseCases.Locale.CreateLocale
{
    public sealed record CreateLocaleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeUpdated { get; set; }
        public UserResponse User { get; set; }
    }
}
