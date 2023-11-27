using Microsoft.EntityFrameworkCore;
using TesteMainteneace.Domain.Entities.Order;
using TesteMainteneace.Domain.Interfaces.Order;
using TesteMainteneace.Persistence.Context;

namespace TesteMainteneace.Persistence.Repositories
{
    public class OrderServiceRepository : BaseEntityIntRepository<OrderServiceEntity>, IOrderServiceRepository
    {
        public OrderServiceRepository(AppDbContext context) : base(context) { }

        public async Task<List<OrderServiceEntity>> GetAllOrdersComplete(CancellationToken cancellationToken)
        {
            var item = await Context.Orders
                .Include(l => l.LocationMainteneace)
                .Include(u => u.UserCreated)
                .Include(f => f.ListFlow)
                    .ThenInclude(f => f.Flow)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return item;
        }

        public async Task<List<OrderServiceEntity>> GetByLocaleExecutation(int id, CancellationToken cancellationToken)
        {
            var item = await Context.Orders.Where(x =>
                                x.LocationMainteneaceId == id)
                                .ToListAsync(cancellationToken);

            return item;
        }
        public async Task<OrderServiceEntity> GetByIdComplete(int id, CancellationToken cancellationToken)
        {
            var item = await Context.Orders
                                    .Include(l => l.LocationMainteneace)
                                    .Include(u => u.UserCreated)
                                    .Include(f => f.ListFlow)
                                        .ThenInclude(f => f.Flow)
                                    .Include(f => f.ListFlow)
                                        .ThenInclude(u => u.InitialUserFlow)
                                        .ThenInclude(u => u.UserInitial)
                                    .Include(f => f.ListFlow)
                                        .ThenInclude(u => u.EndUserFlow)
                                        .ThenInclude(u => u.UserEnd)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x =>
                                       x.Id == id, cancellationToken);

            return item;

        }

    }
}
