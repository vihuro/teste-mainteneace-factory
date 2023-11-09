namespace TesteMainteneace.Domain.Entities.Base
{
    public abstract class BaseEntityInt
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
