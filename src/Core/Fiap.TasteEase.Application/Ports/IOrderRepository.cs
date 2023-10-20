using Fiap.TasteEase.Domain.Aggregates.OrderAggregate;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using Fiap.TasteEase.Domain.Ports;

namespace Fiap.TasteEase.Application.Ports;

public interface IOrderRepository : IRepository<IOrderModel, Order, OrderId, OrderProps>
{
    
}