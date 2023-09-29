using System.Linq.Expressions;
using System.Threading.Tasks;
using Cooprol.Data.Models;
namespace Cooprol.Data.IRepository;

public interface IRepository<TEntity, TId> 
where TId: struct
where TEntity: BaseEntity<TId>
{ 
    Task AddAsync(TEntity entity);
    Task<TEntity> FindAsync(TId id);
    Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter =  null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
    Task Delete(TId id);
}

