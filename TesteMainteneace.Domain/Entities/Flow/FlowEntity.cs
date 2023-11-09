using System.ComponentModel.DataAnnotations.Schema;
using TesteMainteneace.Domain.Entities.Base;

namespace TesteMainteneace.Domain.Entities.Flow
{
    [Table("tab_flow")]
    public sealed class FlowEntity : BaseEntityInt
    {
        public string TypeFlow { get; set; }
    }
}
