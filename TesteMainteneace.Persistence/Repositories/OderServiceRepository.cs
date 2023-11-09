using Microsoft.EntityFrameworkCore;
using TesteMainteneace.Domain.Entities;
using TesteMainteneace.Domain.Interfaces;
using TesteMainteneace.Persistence.Context;

namespace TesteMainteneace.Persistence.Repositories
{
    public class OderServiceRepository : BaseEntityIntRepository<OrderServiceEntity>, IOrderServiceRepository
    {
        public OderServiceRepository(AppDbContext context) : base(context) { }

        public Task<List<OrderServiceEntity>> GetByLocaleExecutation(int id, CancellationToken cancellationToken)
        {
            var item = Context.Orders.Where(x =>
                                x.LocalExecutationId == id)
                                .ToListAsync(cancellationToken);

            return item;
        }
    }
}
