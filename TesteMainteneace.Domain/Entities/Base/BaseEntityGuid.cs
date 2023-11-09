namespace TesteMainteneace.Domain.Entities.Base
{
    public abstract class BaseEntityGuid
    {
        public Guid Id { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime? DateTimeUpdated { get; set; }
    }
}
