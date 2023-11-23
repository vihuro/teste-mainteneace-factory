namespace TesteMainteneace.Application.UseCases.Reports.Storage.GetStorageRadar
{
    public record class GetStorageRadarResponse
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
    }
}
