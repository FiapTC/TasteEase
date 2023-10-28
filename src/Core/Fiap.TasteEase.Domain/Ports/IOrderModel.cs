using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;

namespace Fiap.TasteEase.Domain.Ports;

public interface IOrderModel : IModel
{
    public string? Description { get; set; }
    public OrderStatus Status { get; set; }
    public Guid ClientId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
