using System.ComponentModel.DataAnnotations.Schema;

namespace TesteMainteneace.Domain.Entities
{
    [Table("tab_order_service")]
    public sealed class OrderService : BaseEntityInt
    {
        public string Description { get; set; }
        public int LocalExecutationId { get; set; }
        public LocalExecutation LocalExecutation { get; set; }

    }
}
