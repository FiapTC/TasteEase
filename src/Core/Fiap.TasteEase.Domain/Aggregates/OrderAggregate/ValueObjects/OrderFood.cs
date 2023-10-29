using Fiap.TasteEase.Domain.Aggregates.FoodAggregate;

namespace Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;

public class OrderFood
{
    public Guid FoodId { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public Food Food { get; set; }

    public OrderFood(Guid foodId, int quantity, DateTime createdAt)
    {
        FoodId = foodId;
        Quantity = quantity;
        CreatedAt = createdAt;
    }
    
    public OrderFood(Guid foodId, int quantity, DateTime createdAt, Food food)
    {
        FoodId = foodId;
        Quantity = quantity;
        CreatedAt = createdAt;
        Food = food;
    }
}