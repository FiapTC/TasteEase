using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using Fiap.TasteEase.Domain.Ports;
using Fiap.TasteEase.Infra.Context;
using Fiap.TasteEase.Infra.Models;

namespace Fiap.TasteEase.Infra.Repository;

public class OrderRepository 
    : Repository<OrderModel, Order, OrderId, CreateOrderProps, OrderProps, IOrderModel>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext db) : base(db) { }
}