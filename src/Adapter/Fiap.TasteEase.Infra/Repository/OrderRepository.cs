using System.Linq.Expressions;
using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using Fiap.TasteEase.Domain.Models;
using Fiap.TasteEase.Domain.Ports;
using Fiap.TasteEase.Infra.Context;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Fiap.TasteEase.Infra.Repository;

public class OrderRepository 
    : Repository<OrderModel, Order, OrderId, CreateOrderProps, OrderProps>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext db) : base(db) { }
    
    public override async Task<Result<IEnumerable<Order>>> Get(Expression<Func<OrderModel, bool>> predicate, params Expression<Func<OrderModel, EntityModel>>[] includes)
    {
        var query = DbSet.AsNoTracking();
        query = includes.Aggregate(query, (current, expression) => current.Include(expression));
        var models = await query.Include(i => i.Foods).ThenInclude(i => i.Food).Where(predicate).ToListAsync();
        var aggregates = models.Select(model => 
            Order.Rehydrate(model).ValueOrDefault);
        return Result.Ok(aggregates);
    }
}