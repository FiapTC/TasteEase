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
    public IReadOnlyList<OrderFood> Foods => Props.Foods;

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
        List<OrderFood>? foods = null;

        // if (model.Foods?.Any() ?? false)
        // {
        //     foods = model.Foods
        //     .Select(food => 
        //         new OrderFood(
        //             new OrderFoodProps(
        //                 model.Id,
        //                 food.FoodId,
        //                 food.Quantity, 
        //                 food.CreatedAt
        //             ), 
        //             new OrderFoodId(food.Id)
        //         )
        //     ).ToList();
        // }
        
        var order = new Order(
            new OrderProps(
                model.Description,
                model.Status,
                model.ClientId,
                model.CreatedAt,
                model.UpdatedAt,
                foods
            ), 
            new OrderId(model.Id)
        );
        
        return Result.Ok(order);
    }
    
    public Result<Order> AddFood(List<OrderFood> foods)
    {
        var foodProps = new List<OrderFood>(foods.Count + (Props.Foods?.Count ?? 0));
        foodProps.AddRange(Props?.Foods ?? Enumerable.Empty<OrderFood>());
        foodProps.AddRange(foods);
        
        Props = Props with {
            Foods = foodProps
        };

        return Result.Ok(this);
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
    List<OrderFood>? Foods = null
);

public record CreateOrderProps(
    string Description,
    Guid ClientId
);