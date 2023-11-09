using System.ComponentModel.DataAnnotations.Schema;
using TesteMainteneace.Domain.Entities.StatusOrder;
using TesteMainteneace.Domain.Entities.User;

namespace TesteMainteneace.Domain.Entities.OrderFlow.UserFlow
{
    [Table("tab_end_user_flow")]
    public sealed class EndUserFlow
    {
        public int Id { get; set; }
        public int FlowOrderServiceId { get; set; }
        public FlowOrderServiceEntity FlowOrderService { get;set; }
        public Guid UserEndId { get; set; }
        public UserAuth UserEnd { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
