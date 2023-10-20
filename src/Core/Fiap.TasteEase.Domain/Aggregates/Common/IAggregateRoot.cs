using Fiap.TasteEase.Domain.Ports;
using FluentResults;

namespace Fiap.TasteEase.Domain.Aggregates.Common;

public interface IAggregateRoot<TAggregate, TKey, TProps>
    where TKey : Key 
    where TProps : Props
{
    static abstract Result<TAggregate> Create(TProps props);
    static abstract Result<TAggregate> Rehydrate(TProps props, TKey key);
    static abstract Result<TAggregate> Rehydrate(IModel props);
}