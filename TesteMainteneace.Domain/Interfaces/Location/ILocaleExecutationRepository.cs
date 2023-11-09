using TesteMainteneace.Domain.Entities.Location;
using TesteMainteneace.Domain.Interfaces.Base;

namespace TesteMainteneace.Domain.Interfaces.Location
{
    public interface ILocaleExecutationRepository : IBaseIntRepository<LocalExecutationEntity>
    {
        Task<LocalExecutationEntity> GetByNameLocale(string nameLocale, CancellationToken cancellationToken);
        Task<List<LocalExecutationEntity>> GetWithUser(CancellationToken cancellationToken);
    }
}
