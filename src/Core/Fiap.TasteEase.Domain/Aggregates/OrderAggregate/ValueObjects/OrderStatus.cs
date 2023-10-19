using Fiap.TasteEase.Domain.Aggregates.Common;

namespace Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;

public class OrderStatus : Enumeration
{
    public static OrderStatus Pending = new(0, "pending");
    public static OrderStatus Confirmed = new(1, "confirmed");

    public OrderStatus(int id, string name)
        : base(id, name) { }
}