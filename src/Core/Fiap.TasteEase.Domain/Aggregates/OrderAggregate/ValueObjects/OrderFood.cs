using Fiap.TasteEase.Domain.Aggregates.Common;
using Fiap.TasteEase.Domain.Ports;
using FluentResults;

namespace Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;

public record OrderFood(
    Guid FoodId,
    int Quantity,
    DateTime CreatedAt
);