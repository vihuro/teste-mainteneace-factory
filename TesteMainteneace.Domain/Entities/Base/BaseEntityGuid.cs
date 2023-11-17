namespace TesteMainteneace.Domain.Entities.Base
{
    public abstract class BaseEntityGuid
    {
        public Guid Id { get; set; }
        public DateTime DateTimeCreated { get; set; }
        ///<summary>
        ///Data e hora de atualização. Opcional.
        ///</summary>
        public DateTime? DateTimeUpdated { get; set; }
    }
}
