using System.Linq.Expressions;

namespace Fiap.TasteEase.Application.Ports
{
    public interface IRepository<TEntity> : IDisposable
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
        Task<int> CountAsync();
    }
}