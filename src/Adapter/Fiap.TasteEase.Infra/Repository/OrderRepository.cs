using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using Fiap.TasteEase.Domain.Models;
using Fiap.TasteEase.Infra.Context;

namespace Fiap.TasteEase.Infra.Repository;

public class OrderRepository 
    : Repository<OrderModel, Order, OrderId, CreateOrderProps, OrderProps>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext db) : base(db) { }
}