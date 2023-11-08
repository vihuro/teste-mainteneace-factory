﻿using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Domain.Interfaces
{
    public interface IBaseIntRepository<T> where T : BaseEntityInt
    {
        void Create(T entity);
        void CreateList(List<T> entity);
        void Updated(T entity);
        Task<T> GetById(int id, CancellationToken cancellationToken);
        Task<List<T>> GetAll(CancellationToken cancellationToken);
    }
}
