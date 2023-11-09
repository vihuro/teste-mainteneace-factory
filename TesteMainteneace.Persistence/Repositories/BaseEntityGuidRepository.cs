using Microsoft.EntityFrameworkCore;
using TesteMainteneace.Domain.Entities.Base;
using TesteMainteneace.Domain.Interfaces.Base;
using TesteMainteneace.Persistence.Context;

namespace TesteMainteneace.Persistence.Repositories
{
    public class BaseEntityGuidRepository<T> : IBaseGuidRepository<T> where T : BaseEntityGuid
    {
        protected readonly AppDbContext Context;

        public BaseEntityGuidRepository(AppDbContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            entity.DateTimeCreated = DateTime.UtcNow;
            Context.Add(entity);
        }

        public void CreateList(List<T> entity)
        {
            foreach (var item in entity) 
            {
                item.DateTimeCreated = DateTime.UtcNow;
            }

            Context.AddRange(entity);
        }

        public void Delete(T entity)
        {
            Context.Remove(entity);
        }

        public async Task<T> Get(Guid Id, CancellationToken cancellationToken)
        {
            var entity = await Context.Set<T>()
                               .Where(x => x.Id == Id).FirstOrDefaultAsync(cancellationToken) ??
                throw new Exception("Entity not foud!") { HResult = 404 };
            return entity;
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }

        public void Update(T entity)
        {
            entity.DateTimeUpdated = DateTime.UtcNow;
            Context.Update(entity);
        }
    }
}
