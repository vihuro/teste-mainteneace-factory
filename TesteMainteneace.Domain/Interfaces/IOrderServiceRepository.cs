using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Domain.Interfaces
{
    public interface IOrderServiceRepository : IBaseIntRepository<OrderServiceEntity>
    {
        Task<List<OrderServiceEntity>> GetByLocaleExecutation(int id,CancellationToken cancellationToken);
    }
}
