using System.Linq.Expressions;
using Fiap.TasteEase.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.Common;
using Fiap.TasteEase.Domain.Ports;
using FluentResults;
using Mapster;

namespace Fiap.TasteEase.Infra.Repository;

public abstract class Repository<TEntity, TAggregate, TKey, TProps, TModel> 
    : IRepository<TEntity, TAggregate, TKey, TProps, TModel> 
    where TEntity : Model, TModel
    where TAggregate : IAggregateRoot<TAggregate, TKey, TProps, TModel>
    where TModel : IModel
{
    protected readonly ApplicationDbContext Db;
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(ApplicationDbContext db)
    {
        Db = db;
        DbSet = db.Set<TEntity>();
    }

    public virtual async Task<Result<IEnumerable<TAggregate>>> Get(Expression<Func<TModel, bool>> predicate)
    {
        var models = await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        var aggregates = models.Select(model => 
            TAggregate.Rehydrate(model).ValueOrDefault);
        return Result.Ok(aggregates);
    }
    
    public virtual async Task<Result<TAggregate>> GetById(Guid id)
    {
        var model = await DbSet.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        return model is null ? Result.Fail("not found") : Result.Ok(TAggregate.Rehydrate(model).ValueOrDefault);
    }

    public virtual async Task<Result<IEnumerable<TAggregate>>> GetAll()
    {
        var models = await DbSet.AsNoTracking().ToListAsync();
        var aggregates = models.Select(model => 
            TAggregate.Rehydrate(model).ValueOrDefault);
        return Result.Ok(aggregates);
    }

    public virtual Result<bool> Add(TAggregate aggregate)
    {
        var result = aggregate.Adapt<TEntity>();
        DbSet.Add(result);
        return Result.Ok(true);
    }
    public virtual Result<bool> Update(TAggregate aggregate)
    {
        var result = aggregate.Adapt<TEntity>();
        DbSet.Update(result);
        return Result.Ok(true);
    }

    public virtual Result<bool> Delete(TAggregate aggregate)
    {
        var result = aggregate.Adapt<TEntity>();
        DbSet.Remove(result);
        return Result.Ok(true);
    }

    public async Task<Result<int>> SaveChanges()
    {
        var result = await Db.SaveChangesAsync();
        return Result.Ok(result);
    }
    
    // public async Task<int> CountAsync()
    // {
    //     return await DbSet.CountAsync();
    // }
    //
    // public void Dispose()
    // {
    //     Db?.Dispose();
    // }
}