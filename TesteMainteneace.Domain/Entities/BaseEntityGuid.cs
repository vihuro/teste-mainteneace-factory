namespace TesteMainteneace.Domain.Entities
{
    public abstract class BaseEntityGuid
    {
        public Guid Id { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime? DateTimeUpdated { get; set; }
    }
}
