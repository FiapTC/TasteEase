using Fiap.TasteEase.Domain.Aggregates.Common;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;

namespace Fiap.TasteEase.Domain.Aggregates.OrderAggregate;

public interface IOrderAggregate
    : IAggregateRoot<Order, OrderId, OrderProps> { }