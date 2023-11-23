using Microsoft.EntityFrameworkCore;
using TesteMainteneace.Domain.Entities.StorageParts;
using TesteMainteneace.Domain.Interfaces.Reports;
using TesteMainteneace.Domain.Interfaces.Storage;
using TesteMainteneace.Persistence.Context;

namespace TesteMainteneace.Persistence.Repositories
{
    public class StoragePartsRepository : BaseEntityIntRepository<StoragePartsEntity>, IStoragePartsRepository
    {
        private readonly IReportsStorage _reportsStorage;

        public StoragePartsRepository(AppDbContext context, IReportsStorage reportsStorage) : base(context)
        {
            _reportsStorage = reportsStorage;
        }
        public async Task<List<StoragePartsEntity>> GetNotRegistered(CancellationToken cancellationToken)
        {
            var listOnReports = await _reportsStorage.GetAll();

            var listOnDatabase = await Context.StorageParts.ToListAsync(cancellationToken);

            var validation = listOnReports.Where(database =>
                                    !listOnDatabase.Any(reports => 
                                    database.Code == reports.Code))
                                    .ToList();
            var list = new List<StoragePartsEntity>();

            foreach(var item in validation)
            {
                list.Add(new StoragePartsEntity
                {
                    Code = item.Code,
                    Description = item.Description,
                    Unit = item.Unity
                });
            }

            return list;
        }

        public Task<List<StoragePartsEntity>> UpdatePartsInDatabase(List<StoragePartsEntity> entityList, 
                                                                            CancellationToken cancellationToken)
        {
            Context.StorageParts.AddRange(entityList);

            return Task.FromResult(entityList);
        }

    }
}
