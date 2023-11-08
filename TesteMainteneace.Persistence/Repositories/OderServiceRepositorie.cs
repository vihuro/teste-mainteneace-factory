using Microsoft.EntityFrameworkCore;
using TesteMainteneace.Domain.Entities;
using TesteMainteneace.Domain.Interfaces;
using TesteMainteneace.Persistence.Context;

namespace TesteMainteneace.Persistence.Repositories
{
    public class OderServiceRepositorie : BaseEntityIntRepository<OrderService>, IOrderServiceRepository
    {
        public OderServiceRepositorie(AppDbContext context) : base(context) { }

        public Task<List<OrderService>> GetByLocaleExecutation(int id, CancellationToken cancellationToken)
        {
            var item = Context.Orders.Where(x =>
                                x.LocalExecutationId == id)
                                .ToListAsync(cancellationToken);

            return item;
        }
    }
}
