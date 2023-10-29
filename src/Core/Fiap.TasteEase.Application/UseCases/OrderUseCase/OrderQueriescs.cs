using Fiap.TasteEase.Domain.Aggregates.FoodAggregate.ValueObjects;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using FluentResults;
using MediatR;

namespace Fiap.TasteEase.Application.UseCases.OrderUseCase
{
    public class GetAll : IRequest<Result<IEnumerable<OrderResponseQuery>>>
    {
        public Guid? ClientId { get; init; }
        public OrderStatus? Status { get; init; }
    }

    public record OrderResponseQuery(
        Guid Id,
        string Description,
        OrderStatus Status,
        Guid ClientId,
        string ClientName,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        IEnumerable<OrderFoodResponseQuery>? Foods
    );

    public record OrderFoodResponseQuery(
        Guid FoodId,
        string FoodName,
        FoodType FoodType,
        string FoodDescription,
        int Quantity,
        DateTime CreatedAt
    );
}