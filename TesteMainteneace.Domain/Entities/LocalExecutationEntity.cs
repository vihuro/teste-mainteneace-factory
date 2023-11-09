using System.ComponentModel.DataAnnotations.Schema;

namespace TesteMainteneace.Domain.Entities
{
    [Table("tab_location")]
    public sealed class LocalExecutationEntity : BaseEntityInt
    {
        public string Local { get; set; }
    }
}
