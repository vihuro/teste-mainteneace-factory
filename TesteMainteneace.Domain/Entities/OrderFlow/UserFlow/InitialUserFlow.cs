using System.ComponentModel.DataAnnotations.Schema;
using TesteMainteneace.Domain.Entities.StatusOrder;
using TesteMainteneace.Domain.Entities.User;

namespace TesteMainteneace.Domain.Entities.OrderFlow.UserFlow
{
    [Table("tab_initial_user_flow")]
    public sealed class InitialUserFlow
    {
        public int Id { get; set; }
        public int FlowOrderServiceId { get; set; }
        public FlowOrderServiceEntity FlowOrderService { get; set; }
        public Guid UserInitialId { get; set; }
        public UserAuth UserInitial { get; set; }
        public DateTime DateCreateded { get; set; }
    }
}
