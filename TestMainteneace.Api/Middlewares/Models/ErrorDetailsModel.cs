namespace TestMainteneace.Api.Middlewares.Models
{
    public sealed class ErrorDetailsModel
    {
        public string Logref { get; set; }
        public List<string> Message { get; set; }
    }
}
