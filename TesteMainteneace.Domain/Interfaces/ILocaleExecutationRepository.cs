using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Domain.Interfaces
{
    public interface ILocaleExecutationRepository : IBaseIntRepository<LocalExecutation>
    {
        Task<LocalExecutation> GetByNameLocale(string nameLocale, CancellationToken cancellationToken);
    }
}
