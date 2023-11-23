

using TesteMainteneace.Domain.Entities.StorageParts;
using TesteMainteneace.Domain.Interfaces.Base;

namespace TesteMainteneace.Domain.Interfaces.Storage
{
    public interface IStoragePartsRepository : IBaseIntRepository<StoragePartsEntity>
    {
        Task<List<StoragePartsEntity>> GetNotRegistered(CancellationToken cancellationToken);
        Task<List<StoragePartsEntity>> UpdatePartsInDatabase(List<StoragePartsEntity> entityList, 
                                                                CancellationToken cancellationToken);
    }
}
