using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Persistence.Interfaces
{
    public interface IBaseGuidRepository<T> where T : BaseEntityGuid
    {
        void Create(T entity);
        void CreateList(List<T> entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> Get(Guid Id, CancellationToken cancellationToken);
        Task<List<T>> GetAll(CancellationToken cancellationToken);
    }
}
