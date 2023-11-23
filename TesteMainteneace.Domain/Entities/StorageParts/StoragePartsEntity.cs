
using System.ComponentModel.DataAnnotations.Schema;
using TesteMainteneace.Domain.Entities.Base;

namespace TesteMainteneace.Domain.Entities.StorageParts
{
    [Table("tab_storage_parts")]
    public class StoragePartsEntity : BaseEntityInt
    {
        public string Code{ get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
        public double QuantityMin { get; set; }
        public double QuantityMax { get; set;}
        public double QuantitySec { get; set; }
    }
}
