using System.Linq.Expressions;
using Fiap.TasteEase.Domain.Aggregates.Common;
using Fiap.TasteEase.Domain.Ports;
using FluentResults;

namespace Fiap.TasteEase.Application.Ports;

public interface IRepository<TEntity, TAggregate, TKey, TProps, TModel> 
    where TEntity : TModel
    where TAggregate : IAggregateRoot<TAggregate, TKey, TProps, TModel>
    where TModel : IModel
{
    Task<Result<IEnumerable<TAggregate>>> Get(Expression<Func<TModel, bool>> predicate);
    Task<Result<TAggregate>> GetById(Guid id);
    Task<Result<IEnumerable<TAggregate>>> GetAll();
    // Task Update(TEntity entity);
    // Task Delete(TEntity entity);
    // Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
    // Task<int> SaveChanges();
    // Task<int> CountAsync();
}