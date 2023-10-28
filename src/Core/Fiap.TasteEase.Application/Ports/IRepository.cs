using System.Linq.Expressions;
using Fiap.TasteEase.Domain.Aggregates.Common;
using Fiap.TasteEase.Domain.Ports;
using FluentResults;

namespace Fiap.TasteEase.Application.Ports;

public interface IRepository<TEntity, TAggregate, TKey, TCreateProps, TRehydrateProps, TModel> 
    where TEntity : TModel
    where TAggregate : IAggregateRoot<TAggregate, TKey, TCreateProps, TRehydrateProps, TModel>
    where TModel : IModel
{
    Task<Result<IEnumerable<TAggregate>>> Get(Expression<Func<TModel, bool>> predicate);
    Task<Result<TAggregate>> GetById(Guid id);
    Task<Result<IEnumerable<TAggregate>>> GetAll();
    Result<bool> Add(TAggregate model);
    Result<bool> Update(TAggregate aggregate);
    // Task Delete(TEntity entity);
    Task<Result<int>> SaveChanges();
}