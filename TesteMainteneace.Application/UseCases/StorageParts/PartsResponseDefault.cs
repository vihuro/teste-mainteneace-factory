
namespace TesteMainteneace.Application.UseCases.StorageParts
{
    public record class PartsResponseDefault
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
        public double QuantityMin { get; set; }
        public double QuantityMax { get; set; }
        public double QuantitySec { get; set; }
    }
}
