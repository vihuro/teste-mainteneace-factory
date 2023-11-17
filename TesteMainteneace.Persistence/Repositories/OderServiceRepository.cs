﻿using Microsoft.EntityFrameworkCore;
using TesteMainteneace.Domain.Entities.Order;
using TesteMainteneace.Domain.Interfaces.Order;
using TesteMainteneace.Persistence.Context;

namespace TesteMainteneace.Persistence.Repositories
{
    public class OderServiceRepository : BaseEntityIntRepository<OrderServiceEntity>, IOrderServiceRepository
    {
        public OderServiceRepository(AppDbContext context) : base(context) { }

        public async Task<List<OrderServiceEntity>> GetAllOrdersComplete(CancellationToken cancellationToken)
        {
            var item = await Context.Orders
                .Include(l => l.LocationMainteneace)
                .Include(u => u.UserCreated)
                .AsNoTracking()
                .ToListAsync();

            return item;
        }

        public Task<List<OrderServiceEntity>> GetByLocaleExecutation(int id, CancellationToken cancellationToken)
        {
            var item = Context.Orders.Where(x =>
                                x.LocationMainteneaceId == id)
                                .ToListAsync(cancellationToken);

            return item;
        }
    }
}
