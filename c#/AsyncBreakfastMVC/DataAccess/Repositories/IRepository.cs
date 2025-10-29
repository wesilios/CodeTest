using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AsyncBreakfastMVC.DataAccess.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    ValueTask<TEntity> GetByIdAsync<T>(T id);
    Task<ICollection<TEntity>> GetAllAsync();
    Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}