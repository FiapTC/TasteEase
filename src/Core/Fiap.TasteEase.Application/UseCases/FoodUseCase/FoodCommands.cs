using Fiap.TasteEase.Domain.Aggregates.FoodAggregate.ValueObjects;
using FluentResults;
using MediatR;

namespace Fiap.TasteEase.Application.UseCases.FoodUseCase
{
    public class Create : IRequest<Result<string>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFoodType Type { get; set; }
        public Guid ClientId { get; set; }
    }
}