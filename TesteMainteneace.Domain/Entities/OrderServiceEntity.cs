using System.ComponentModel.DataAnnotations.Schema;

namespace TesteMainteneace.Domain.Entities
{
    [Table("tab_order_service")]
    public sealed class OrderServiceEntity : BaseEntityInt
    {
        public string Description { get; set; }
        public int LocalExecutationId { get; set; }
        public LocalExecutationEntity LocalExecutation { get; set; }

    }
}
