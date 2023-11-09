using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Domain.Interfaces
{
    public interface ILogsRepository
    {
        Task<LogsEntity> CreateLog(LogsEntity entity);
        Task<List<LogsEntity>> GetAll(CancellationToken cancellationToken);
        Task<LogsEntity> GetLogId(Guid Id, CancellationToken cancellationToken);
    }
}
