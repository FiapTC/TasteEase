using Fiap.TasteEase.Domain.Aggregates.Common;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using FluentResults;

namespace Fiap.TasteEase.Domain.Aggregates.OrderAggregate;

public class Order : Entity<OrderId, OrderProps>, IOrderAggregate
{
    public Order(OrderProps props, OrderId? id = default) : base(props, id) { }

    public string Description => Props.Description;
    public OrderStatus Status => Props.Status;
    public DateTime CreatedAt => Props.CreatedAt;
    public string CreatedBy => Props.CreatedBy;
    public DateTime UpdatedAt => Props.UpdatedAt;
    public string UpdatedBy => Props.UpdatedBy;

    public static Result<Order> Create(OrderProps props)
    {
        var date = DateTime.UtcNow;
        var order = new Order(
            new OrderProps(
            props.Description,
            props.Status,
            date,
            props.CreatedBy,
            date,
            props.UpdatedBy
        ));

        return Result.Ok(order);
    }

    public static Result<Order> Rehydrate(OrderProps props, OrderId id)
        => Result.Ok(new Order(props, id));

    public Result<Order> UpdateStatus(OrderStatus newStatus)
    {
        Props = Props with { 
            Status = newStatus,
            UpdatedAt = DateTime.UtcNow
        };

        return Result.Ok(this);
    }
}

public record OrderProps(
    string Description,
    OrderStatus Status,
    DateTime CreatedAt,
    string CreatedBy,
    DateTime UpdatedAt,
    string UpdatedBy
);