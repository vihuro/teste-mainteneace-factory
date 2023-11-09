namespace TesteMainteneace.Application.UseCases.Logs.GetLogs
{
    public sealed record GetLogsResponse
    {
        public Guid Id { get; set; }
        public string ClassError { get; set; }
        public string LineError { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string LogRef { get; set; }
        public List<string> Erros { get; set; }
    }
}
