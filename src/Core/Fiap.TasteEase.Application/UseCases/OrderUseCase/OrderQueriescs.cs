using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using FluentResults;
using MediatR;

namespace Fiap.TasteEase.Application.UseCases.OrderUseCase
{
    public class GetAll : IRequest<Result<IEnumerable<OrderResponseDto>>> { }

    public record OrderResponseDto(
        Guid Id,
        string Description,
        OrderStatus Status,
        Guid ClientId,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        IEnumerable<OrderFoodResponseDto>? Foods
    );

    public record OrderFoodResponseDto(
        Guid FoodId,
        int Quantity,
        DateTime CreatedAt
    );
}