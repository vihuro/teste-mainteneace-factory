using TesteMainteneace.Application.UseCases.User;

namespace TesteMainteneace.Application.UseCases.Locale
{
    public sealed record LocaleDefault
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public UserResponse UserAuth { get; set; }
    }
}
