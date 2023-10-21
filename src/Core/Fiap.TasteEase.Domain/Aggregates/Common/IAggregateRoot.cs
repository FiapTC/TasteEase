using Fiap.TasteEase.Domain.Ports;
using FluentResults;

namespace Fiap.TasteEase.Domain.Aggregates.Common;

public interface IAggregateRoot<TAggregate, TKey, TProps, TModel>
    where TKey : Key 
    where TProps : Props
    where TModel : IModel
{
    static abstract Result<TAggregate> Create(TProps props);
    static abstract Result<TAggregate> Rehydrate(TProps props, TKey key);
    static abstract Result<TAggregate> Rehydrate(TModel props);
}