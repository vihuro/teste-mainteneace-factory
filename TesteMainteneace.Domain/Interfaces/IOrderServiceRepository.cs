using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Domain.Interfaces
{
    public interface IOrderServiceRepository : IBaseIntRepository<OrderService>
    {
        Task<List<OrderService>> GetByLocaleExecutation(int id,CancellationToken cancellationToken);
    }
}
