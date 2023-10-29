using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;

namespace Fiap.TasteEase.Api.ViewModels.Order;

public record OrderResponse(
    Guid Id,
    string Description,
    OrderStatus Status,
    Guid ClientId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    IEnumerable<OrderFoodResponse>? Foods
);

public record OrderFoodResponse(
    Guid FoodId,
    int Quantity,
    DateTime CreatedAt
);