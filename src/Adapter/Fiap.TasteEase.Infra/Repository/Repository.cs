using Fiap.TasteEase.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.Common;

namespace Fiap.TasteEase.Infra.Repository
{
    public abstract class Repository<TEntity, TKey, TProps> 
        : IRepository<TEntity> 
        where TEntity : Entity<TKey, TProps>
        where TKey : class
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ApplicationDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual async Task Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await DbSet.CountAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}