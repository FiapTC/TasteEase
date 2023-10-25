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
    public DateTime CreatedAt => Props.CreatedAt;
    public string CreatedBy => Props.CreatedBy;
    public DateTime UpdatedAt => Props.UpdatedAt;
    public string UpdatedBy => Props.UpdatedBy;
    public IReadOnlySet<OrderFood> Foods => Props.Foods;

    public static Result<Order> Create(OrderProps props)
    {
        var date = DateTime.UtcNow;
        var order = new Order(
            props with
            {
                CreatedAt = date, 
                UpdatedAt = date
            }
        );
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
                model.CreatedBy,
                model.UpdatedBy,
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
    string CreatedBy,
    string UpdatedBy,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    IReadOnlySet<OrderFood>? Foods = null
);