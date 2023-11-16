using System.ComponentModel.DataAnnotations.Schema;
using TesteMainteneace.Domain.Entities.Base;
using TesteMainteneace.Domain.Entities.Order;
using TesteMainteneace.Domain.Entities.User;

namespace TesteMainteneace.Domain.Entities.Daily
{
    [Table("tab_daily")]
    public sealed class DailyEntity : BaseEntityInt
    {
        public string Observation { get; set; }
        public Guid UserCreatedId { get; set; }
        public UserAuth UserCreated { get; set; }
        public int OrderServiceId { get; set; }
        public OrderServiceEntity OrderService { get; set; }
    }
}
