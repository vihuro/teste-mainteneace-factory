using System.ComponentModel.DataAnnotations.Schema;
using TesteMainteneace.Domain.Entities.Base;
using TesteMainteneace.Domain.Entities.User;

namespace TesteMainteneace.Domain.Entities.Location
{
    [Table("tab_location")]
    public sealed class LocalExecutationEntity : BaseEntityInt
    {
        public string Local { get; set; }
        public Guid UserAuthId { get; set; }
        public UserAuth UserAuth { get; set; }
    }
}
