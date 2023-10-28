using Fiap.TasteEase.Domain.Aggregates.Common;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using Fiap.TasteEase.Domain.Ports;
using FluentResults;

namespace Fiap.TasteEase.Domain.Aggregates.OrderAggregate;

public class Order : Entity<OrderId, OrderProps>, IOrderAggregate
{
    public Order(OrderProps props, OrderId? id = default) : base(props, id) { }

    public string Description => Props.Description;
    public OrderStatus Status => Props.Status;
    public Guid ClientId => Props.ClientId;
    public DateTime CreatedAt => Props.CreatedAt;
    public DateTime UpdatedAt => Props.UpdatedAt;
    public IReadOnlySet<OrderFood> Foods => Props.Foods;

    public static Result<Order> Create(CreateOrderProps props)
    {
        var date = DateTime.UtcNow;
        var orderProps = new OrderProps(
            props.Description,
            OrderStatus.Created,
            props.ClientId,
            date,
            date
        );
        
        var order = new Order(orderProps);
        return Result.Ok(order);
    }

    public static Result<Order> Rehydrate(OrderProps props, OrderId id)
        => Result.Ok(new Order(props, id));

    public static Result<Order> Rehydrate(IOrderModel model)
    {
        var order = new Order(
            new OrderProps(
                model.Description,
                model.Status,
                model.ClientId,
                model.CreatedAt,
                model.UpdatedAt
            ), 
            new OrderId(model.Id)
        );
        
        return Result.Ok(order);
    }

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
    Guid ClientId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    IReadOnlySet<OrderFood>? Foods = null
);

public record CreateOrderProps(
    string Description,
    Guid ClientId,
    IReadOnlySet<OrderFood>? Foods = null
);