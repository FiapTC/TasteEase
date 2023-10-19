using FluentResults;

namespace Fiap.TasteEase.Domain.Aggregates.Common;

public interface IAggregateRoot<TKey, TProps, TEntity>
{
    static abstract Result<TEntity> Create(TProps props);
    static abstract Result<TEntity> Rehydrate(TProps props, TKey key);
}