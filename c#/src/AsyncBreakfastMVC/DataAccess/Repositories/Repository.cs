using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AsyncBreakfastMVC.DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext Context;

    public Repository(DbContext context)
    {
        Context = context;
    }

    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await Context.Set<TEntity>().AddRangeAsync(entities);
    }


    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().Where(predicate);
    }

    public async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }

    public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public ValueTask<TEntity> GetByIdAsync<T>(T id)
    {
        return Context.Set<TEntity>().FindAsync(id);
    }

    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        Context.Set<TEntity>().RemoveRange(entities);
    }

    public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
    }
}