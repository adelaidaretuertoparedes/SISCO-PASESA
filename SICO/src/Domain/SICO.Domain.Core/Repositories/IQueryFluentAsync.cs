using SICO.Domain.Core.Paged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SICO.Domain.Core.Repositories
{
    public interface IQueryFluentAsync<TEntity> : IQueryFluent<TEntity>
    {
        IQueryFluentAsync<TEntity> IncludeAsync(Expression<Func<TEntity, object>> expression);
        IQueryFluentAsync<TEntity> OrderByAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
        Task<IEnumerable<TEntity>> SelectAsync();
        Task<IPagedList<TEntity>> SelectPageAsync(int page, int pageSize);
    }
}
