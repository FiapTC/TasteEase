using Fiap.TasteEase.Domain.Aggregates.OrderAggregate;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using Fiap.TasteEase.Domain.Models;
using Fiap.TasteEase.Domain.Ports;

namespace Fiap.TasteEase.Application.Ports;

public interface IOrderRepository 
    : IRepository<OrderModel, Order>
{
    
}