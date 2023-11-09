using TesteMainteneace.Domain.Entities.System;

namespace TesteMainteneace.Domain.Interfaces.System
{
    public interface ILogsRepository
    {
        Task<LogsEntity> CreateLog(LogsEntity entity);
        Task<List<LogsEntity>> GetAll(CancellationToken cancellationToken);
        Task<LogsEntity> GetLogId(Guid Id, CancellationToken cancellationToken);
    }
}
