using System.Linq.Expressions;
using Cooprol.Data.IRepository;
using Cooprol.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace Cooprol.Data.Repository;
public class Repository<TEntity, TId> : IRepository<TEntity, TId>
where TId : struct
where TEntity : BaseEntity<TId>
{
    internal CooprolContext _context;
    internal DbSet<TEntity> _dbSet;
    public Repository(CooprolContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual async Task Delete(TEntity entity)
    {
        if(_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);                
        }
        _dbSet.Remove(entity);
    }

    public virtual async Task Delete(TId id)
    {
        TEntity entitToDetelete = await _dbSet.FindAsync(id);
        Delete(entitToDetelete);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>> filter = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
        string includeProperties = "")
    {
        IQueryable<TEntity> query = _dbSet;
        if(filter is not null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split(
            new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if(orderBy is not null)
        {
            return await orderBy(query).ToListAsync();
        }
        else
        {
            return await query.ToListAsync();
        }
    }

    public virtual  async Task<TEntity>  FindAsync(TId id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task Update(TEntity entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

}