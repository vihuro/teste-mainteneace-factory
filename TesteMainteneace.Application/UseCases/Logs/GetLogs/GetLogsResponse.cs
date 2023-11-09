namespace TesteMainteneace.Application.UseCases.Logs.GetLogs
{
    public sealed record GetLogsResponse
    {
        public Guid Id { get; set; }
        public string LogRef { get; set; }
        public List<string> Message { get; set; }
    }
}
