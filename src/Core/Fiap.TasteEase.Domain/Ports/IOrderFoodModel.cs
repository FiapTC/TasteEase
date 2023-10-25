using Fiap.TasteEase.Domain.Aggregates.FoodAggregate.ValueObjects;

namespace Fiap.TasteEase.Domain.Ports
{
    public interface IOrderFoodModel : IModel
    {
        public Guid FoodId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}