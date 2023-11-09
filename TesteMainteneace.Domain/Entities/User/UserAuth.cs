using System.ComponentModel.DataAnnotations.Schema;
using TesteMainteneace.Domain.Entities.Base;

namespace TesteMainteneace.Domain.Entities.User
{
    [Table("tab_user_auth")]
    public sealed class UserAuth : BaseEntityGuid
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Actived { get; set; }
    }
}
