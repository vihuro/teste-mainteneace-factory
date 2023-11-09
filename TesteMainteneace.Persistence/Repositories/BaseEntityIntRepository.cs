using Microsoft.EntityFrameworkCore;
using TesteMainteneace.Domain.Entities.Base;
using TesteMainteneace.Domain.Interfaces.Base;
using TesteMainteneace.Persistence.Context;

namespace TesteMainteneace.Persistence.Repositories
{
    public class BaseEntityIntRepository<T> : IBaseIntRepository<T> where T : BaseEntityInt
    {
        protected readonly AppDbContext Context;

        public BaseEntityIntRepository(AppDbContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            Context.Add(entity);
        }

        public void CreateList(List<T> entity)
        {
            foreach (var item in entity)
            {
                item.DateCreated = DateTime.UtcNow;
            }
            Context.Add(entity);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await Context
                .Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T> GetById(int id, CancellationToken cancellationToken)
        {
            var entity = await Context.Set<T>()
                        .FirstOrDefaultAsync(x => 
                        x.Id == id, cancellationToken) ??
                throw new Exception("Not found");
            return entity;
        }

        public void Updated(T entity)
        {
            entity.DateUpdated = DateTime.UtcNow;
            Context.Update(entity);
        }
    }
}
