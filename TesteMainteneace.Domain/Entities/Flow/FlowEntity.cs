using System.ComponentModel.DataAnnotations.Schema;
using TesteMainteneace.Domain.Entities.Base;

namespace TesteMainteneace.Domain.Entities.Flow
{
    [Table("tab_flow")]
    public sealed class FlowEntity
    {
        public int Id { get; set; }
        public string TypeFlow { get; set; }
    }
}
