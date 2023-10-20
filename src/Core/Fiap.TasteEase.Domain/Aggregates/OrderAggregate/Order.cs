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

    public static Result<Order> Rehydrate(IModel model)
    {
        var orderModel = model as IOrderModel;
        var order = new Order(
            new OrderProps(
                orderModel.Description,
                orderModel.Status,
                orderModel.CreatedAt,
                orderModel.CreatedBy,
                orderModel.UpdatedAt,
                orderModel.UpdatedBy
            ), 
            new OrderId(orderModel.Id)
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
    DateTime CreatedAt,
    string CreatedBy,
    DateTime UpdatedAt,
    string UpdatedBy
) : Props;

public class OrderModelTeste
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string UpdatedBy { get; set; }
}