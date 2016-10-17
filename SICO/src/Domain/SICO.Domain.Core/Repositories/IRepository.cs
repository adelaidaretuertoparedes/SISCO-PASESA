using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SICO.Domain.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void BatchDelete(Expression<Func<TEntity, bool>> predicate);

        void BatchUpdate(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> properties);

        void BulkInsert(IEnumerable<TEntity> entities);

        void BulkUpdate(IEnumerable<TEntity> entities);

        void Delete(params object[] keyValues);

        void Delete(TEntity entity, bool isLogical = true);

        void Delete(Expression<Func<TEntity, bool>> predicate);

        void DeleteRange(IEnumerable<TEntity> entities, bool isLogical = true);

        bool Exists(params object[] keyValues);

        TEntity Get(Func<TEntity, Boolean> where);

        TResult Get<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(params object[] keyValues);
        TEntity GetFirst(Func<TEntity, bool> predicate);

        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> GetManyQueryable(Expression<Func<TEntity, bool>> where);

        IRepository<T> GetRepository<T>() where T : class;

        TEntity GetSingle(Func<TEntity, bool> predicate);

        IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        void Insert(TEntity entity);

        void InsertGraph(TEntity entity);
        void InsertGraphRange(IEnumerable<TEntity> entities);

        void InsertRange(IEnumerable<TEntity> entities);
        IQueryFluentAsync<TEntity> Query();

        IQueryFluentAsync<TEntity> Query(IQueryObject<TEntity> queryObject);

        IQueryFluentAsync<TEntity> Query(Expression<Func<TEntity, bool>> query);

        IQueryable<TEntity> Queryable();

        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);

        IEnumerable<TResult> SelectQuery<TResult>(string query, params KeyValuePair<string, object>[] parameters);

        void Update(TEntity entityToUpdate);
        void Update(TEntity entityToUpdate, params Expression<Func<TEntity, object>>[] properties);
    }
}
