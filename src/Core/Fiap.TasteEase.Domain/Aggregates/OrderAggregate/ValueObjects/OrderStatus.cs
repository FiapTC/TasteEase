namespace Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;

public enum OrderStatus
{
    Created,
    Paid,
    Preparing,
    Prepared,
    Delivered
}