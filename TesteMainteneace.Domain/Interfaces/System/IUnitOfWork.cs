namespace TesteMainteneace.Domain.Interfaces.System
{
    public interface IUnitOfWork
    {
        Task Commit(CancellationToken cancellationToken);
    }
}
