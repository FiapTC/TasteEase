﻿using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;

namespace Fiap.TasteEase.Api.ViewModels.Order;

public record OrderRequest(
    string Description,
    OrderStatus Status,
    Guid ClientId,
    IReadOnlySet<OrderFoodRequest>? Foods = null
);

public record OrderFoodRequest(
    Guid FoodId,
    int Quantity
);