using MongoDB.Driver;
using TesteMainteneace.Domain.Entities;
using TesteMainteneace.Domain.Interfaces;
using TesteMainteneace.Persistence.Context;

namespace TesteMainteneace.Persistence.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly MongoDbContext _mongoDbContext;

        public LogsRepository(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task<LogsEntity> CreateLog(LogsEntity entity)
        {
            await _mongoDbContext.Logs.InsertOneAsync(entity);

            return entity;
        }

        public async Task<List<LogsEntity>> GetAll(CancellationToken cancellationToken)
        {
            var list = await _mongoDbContext.Logs
                            .Find(_ => true).ToListAsync(cancellationToken);

            return list;

            throw new NotImplementedException();
        }

        public Task<LogsEntity> GetLogId(Guid Id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
