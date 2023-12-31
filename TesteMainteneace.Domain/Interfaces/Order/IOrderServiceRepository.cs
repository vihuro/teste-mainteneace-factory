﻿using TesteMainteneace.Domain.Entities.Order;
using TesteMainteneace.Domain.Interfaces.Base;

namespace TesteMainteneace.Domain.Interfaces.Order
{
    public interface IOrderServiceRepository : IBaseIntRepository<OrderServiceEntity>
    {
        Task<List<OrderServiceEntity>> GetByLocaleExecutation(int id, CancellationToken cancellationToken);
        Task<OrderServiceEntity> GetByIdComplete(int id, CancellationToken cancellationToken);
        Task<List<OrderServiceEntity>> GetAllOrdersComplete(CancellationToken cancellationToken);
    }
}
