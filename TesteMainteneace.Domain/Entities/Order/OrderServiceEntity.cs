using System.ComponentModel.DataAnnotations.Schema;
using TesteMainteneace.Domain.Entities.Base;
using TesteMainteneace.Domain.Entities.Daily;
using TesteMainteneace.Domain.Entities.Location;
using TesteMainteneace.Domain.Entities.Order.Enun;
using TesteMainteneace.Domain.Entities.User;

namespace TesteMainteneace.Domain.Entities.Order
{
    [Table("tab_order_service")]
    public sealed class OrderServiceEntity : BaseEntityInt
    {
        public string Description { get; set; }
        public int LocationMainteneaceId { get; set; }
        public LocalExecutationEntity LocationMainteneace { get; set; }
        public DateTime SuggestedMainteneaceDate { get; set; }
        public Guid UserCreatedId { get; set; }
        public UserAuth UserCreated { get; set; }
        public ESituationOrderService Situacion { get; set; }
        public ETypeMainteneace Type { get; set; }
        public EPriority Priority { get; set; }
        public ECategoty Category { get; set; }
        public List<DailyEntity> Daily { get; set; }

    }
}
