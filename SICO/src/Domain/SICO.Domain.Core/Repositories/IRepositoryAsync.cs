using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SICO.Domain.Core.Repositories
{
    public interface IRepositoryAsync<TEntity> : IRepository<TEntity> where TEntity : class
    {
        Task BatchDeleteAsync<TAudit>(Expression<Func<TEntity, bool>> predicate, TAudit audit, bool isLogical = true) where TAudit : AuditEntityBase;

        Task BatchUpdateAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> properties);

        Task BulkInsertAsync(IEnumerable<TEntity> entities);

        Task BulkUpdateAsync(IEnumerable<TEntity> entities);

        Task<bool> ExistsAsync(params object[] keyValues);
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);
        Task<TResult> GetAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector);
        Task<TEntity> GetByIdAsync(params object[] keyValues);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> predicate);

        IRepositoryAsync<T> GetRepositoryAsync<T>() where T : class;

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
