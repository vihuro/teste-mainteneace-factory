using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Domain.Interfaces
{
    public interface ILocaleExecutationRepository : IBaseIntRepository<LocalExecutationEntity>
    {
        Task<LocalExecutationEntity> GetByNameLocale(string nameLocale, CancellationToken cancellationToken);
    }
}
