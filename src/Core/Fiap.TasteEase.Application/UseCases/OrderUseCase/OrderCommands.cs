using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using FluentResults;
using MediatR;

namespace Fiap.TasteEase.Application.UseCases.OrderUseCase
{
    public class Create : IRequest<Result<OrderResponseCommand>>
    {
        public string Description { get; set; }
        public Guid ClientId { get; set; }
        public IEnumerable<OrderFoodCreate>? Foods { get; set; } = null;
    }

    public record OrderFoodCreate(
        Guid FoodId,
        int Quantity
    );
    
    public record OrderResponseCommand(
        Guid OrderId,
        Guid ClientId,
        decimal TotalPrice,
        OrderStatus Status
    );
}