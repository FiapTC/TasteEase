using Fiap.TasteEase.Domain.Aggregates.FoodAggregate.ValueObjects;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using FluentResults;
using MediatR;

namespace Fiap.TasteEase.Application.UseCases.OrderUseCase
{
    public class GetAll : IRequest<Result<IEnumerable<OrderResponseDto>>>
    {
        public Guid? ClientId { get; init; }
        public OrderStatus? Status { get; init; }
    }

    public record OrderResponseDto(
        Guid Id,
        string Description,
        OrderStatus Status,
        Guid ClientId,
        string ClientName,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        IEnumerable<OrderFoodResponseDto>? Foods
    );

    public record OrderFoodResponseDto(
        Guid FoodId,
        string FoodName,
        FoodType FoodType,
        string FoodDescription,
        int Quantity,
        DateTime CreatedAt
    );
}