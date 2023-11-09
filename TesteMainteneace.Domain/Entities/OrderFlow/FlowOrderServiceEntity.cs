using System.ComponentModel.DataAnnotations.Schema;
using TesteMainteneace.Domain.Entities.Base;
using TesteMainteneace.Domain.Entities.Flow;
using TesteMainteneace.Domain.Entities.Order;
using TesteMainteneace.Domain.Entities.OrderFlow.UserFlow;

namespace TesteMainteneace.Domain.Entities.StatusOrder
{
    [Table("tab_flow_order_service")]
    public sealed class FlowOrderServiceEntity : BaseEntityInt
    {
        public int OrderId { get; set; }
        public OrderServiceEntity OrderService { get; set; }
        public int FlowId { get; set; }
        public FlowEntity Flow { get; set; }
        public string Description { get; set; }
        public InitialUserFlow InitialUserFlow { get; set; }
        public EndUserFlow EndUserFlow { get; set; }

    }
}
