using Fiap.TasteEase.Domain.Aggregates.Common;
using Fiap.TasteEase.Domain.Ports;
using FluentResults;

namespace Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;

public class OrderFood : 
    Entity<OrderFoodId, OrderFoodProps>, 
    IAggregateRoot<OrderFood, OrderFoodId, OrderFoodProps, IOrderFoodModel>
{
    public OrderFood(OrderFoodProps props, OrderFoodId? id = default) : base(props, id) { }

    public Guid OrderId => Props.OrderId;
    public Guid FoodId => Props.FoodId;
    public int Quantity => Props.Quantity;
    public DateTime CreatedAt => Props.CreatedAt;
    
    public static Result<OrderFood> Create(OrderFoodProps props)
    {
        var date = DateTime.UtcNow;
        var order = new OrderFood(
            props with
            {
                CreatedAt = date
            }
        );
        return Result.Ok(order);
    }

    public static Result<OrderFood> Rehydrate(OrderFoodProps props, OrderFoodId id)
        => Result.Ok(new OrderFood(props, id));

    public static Result<OrderFood> Rehydrate(IOrderFoodModel model)
    {
        var orderFood = new OrderFood(
            new OrderFoodProps(
                model.OrderId,
                model.FoodId,
                model.Quantity,
                model.CreatedAt
            ), 
            new OrderFoodId(model.Id)
        );
        
        return Result.Ok(orderFood);
    }
}
    
public record OrderFoodProps(
    Guid OrderId,
    Guid FoodId,
    int Quantity,
    DateTime CreatedAt
);