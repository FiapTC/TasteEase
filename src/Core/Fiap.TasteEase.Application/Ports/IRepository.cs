using System.Linq.Expressions;
using Fiap.TasteEase.Domain.Aggregates.Common;
using Fiap.TasteEase.Domain.Ports;
using FluentResults;

namespace Fiap.TasteEase.Application.Ports;

public interface IRepository<TEntity, TAggregate, TKey, TCreateProps, TRehydrateProps, TModel>
{
    Task<Result<IEnumerable<TAggregate>>> Get(Expression<Func<TModel, bool>> predicate);
    Task<Result<TAggregate>> GetById(Guid id);
    Task<Result<IEnumerable<TAggregate>>> GetAll();
    Result<bool> Add(TAggregate model);
    Result<bool> Update(TAggregate aggregate);
    Result<bool> Delete(TAggregate aggregate);
    Task<Result<int>> SaveChanges();
}