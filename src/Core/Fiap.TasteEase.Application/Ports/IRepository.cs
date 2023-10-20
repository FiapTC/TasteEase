using System.Linq.Expressions;
using Fiap.TasteEase.Domain.Aggregates.Common;
using Fiap.TasteEase.Domain.Ports;
using FluentResults;

namespace Fiap.TasteEase.Application.Ports
{
    public interface IRepository<TEntity, TAggregate, TKey, TProps> 
        where TEntity : IModel
        where TAggregate : IAggregateRoot<TAggregate, TKey, TProps>
        where TKey : Key 
        where TProps : Props
    {
        // Task Add(TEntity entity);
        // Task<TEntity> GetById(Guid id);
        Task<Result<IEnumerable<TAggregate>>> GetAll();
        // Task Update(TEntity entity);
        // Task Delete(TEntity entity);
        // Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        // Task<int> SaveChanges();
        // Task<int> CountAsync();
    }
}