using Fiap.TasteEase.Domain.Aggregates.FoodAggregate.ValueObjects;

namespace Fiap.TasteEase.Domain.Ports
{
    public interface IFoodModel : IModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public FoodType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}