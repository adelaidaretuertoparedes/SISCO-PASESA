using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using SICO.Domain.Core;
using System.Data.Entity;
using SICO.Infrastructure.CrossCutting.Common;
using SICO.Domain.Core.Repositories;
using SICO.Domain.Core.UnitOfWorks;
using SICO.Infrastructure.Data.Core.Queries;
using LinqKit;
using EntityFramework.Extensions;

namespace SICO.Infrastructure.Data.Core
{
    public class Repository<TEntity> : IRepositoryAsync<TEntity> 
        where TEntity : AuditEntityBase, new()

    {
        private readonly IDataContextAsync _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IUnitOfWorkAsync _unitOfWork;

        public Repository(IDataContextAsync context, IUnitOfWorkAsync unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            var dbContext = context as DbContext;
            if (dbContext != null)
            { 
                _dbSet = dbContext.Set<TEntity>();
            }
        }
        public void BatchDelete(Expression<Func<TEntity, bool>> predicate)
        {
            _dbSet.Where(predicate).Delete();
        }
        public async Task BatchDeleteAsync<TAudit>(Expression<Func<TEntity, bool>> predicate, TAudit audit,bool isLogical = true) where TAudit: AuditEntityBase
        {            
            if (isLogical)
            {
                await BatchUpdateAsync(predicate, x => new TEntity() {
                    UpdaterUser=audit.UpdaterUser,
                    UpdaterIpAddress=audit.UpdaterIpAddress,
                    UpdateDate=DateTime.UtcNow,
                    Status=false
                });
            }
            else {
                await _dbSet.Where(predicate).DeleteAsync();
            }
            
        }
        public void BatchUpdate(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> properties)
        {            
            _dbSet.Where(predicate).Update(properties);            
        }
        public async Task BatchUpdateAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> properties)
        {
            await _dbSet.Where(predicate).UpdateAsync(properties);
        }
        public void BulkInsert(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
        public Task BulkInsertAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
        public void BulkUpdate(IEnumerable<TEntity> entities)
        {
            _context.PerformBulkUpdate(entities);
        }
        public async Task BulkUpdateAsync(IEnumerable<TEntity> entities)
        {
           await _context.PerformBulkUpdateAsync(entities);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> objects = _dbSet.Where(predicate).AsQueryable();
            foreach (TEntity obj in objects)
                Delete(obj);
        }
        public void Delete(TEntity entity, bool isLogical = true)
        {            
            if (isLogical)
            {
                entity.Status = false;
                Update(entity, p => p.Status);
            }
            else
            {
                PhysicalDelete(entity);         
            }
            
        }
        public void Delete(params object[] keyValues)
        {
            TEntity entityToDelete = _dbSet.Find(keyValues);
            Delete(entityToDelete);
        }
        public void DeleteRange(IEnumerable<TEntity> entities, bool isLogical = true)
        {
            foreach (TEntity entity in entities) {
                Delete(entity,isLogical);
            }
        }
        public bool Exists(params object[] keyValues)
        {
            return _dbSet.Find(keyValues) != null;
        }
        public async Task<bool> ExistsAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues) != null;
        }

        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await FindAsync(CancellationToken.None, keyValues);
        }

        public async Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return await _dbSet.FindAsync(cancellationToken, keyValues);
        }

        public TEntity Get(Func<TEntity, bool> where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }

        public TResult Get<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        {
            return _dbSet.Where(predicate).Select(selector).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.FirstOrDefaultAsync(where);
        }

        public async Task<TResult> GetAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        {
            return await _dbSet.Where(predicate).Select(selector).FirstOrDefaultAsync();
        }

        public TEntity GetById(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public async Task<TEntity> GetByIdAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return _dbSet.First(predicate);
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstAsync(predicate);
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public IQueryable<TEntity> GetManyQueryable(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where).AsQueryable();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return _unitOfWork.Repository<T>();
        }

        public IRepositoryAsync<T> GetRepositoryAsync<T>() where T : class
        {
            return _unitOfWork.RepositoryAsync<T>();
        }

        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return _dbSet.Single(predicate);
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleAsync(predicate);
        }

        public IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            return includes.Aggregate(query, (current, include) => current.Include(include));
        }

        public void Insert(TEntity entity)
        {
            entity.Status = true;
            _dbSet.Attach(entity);
            _context.SyncObjectState(entity, ObjectState.Added);
        }

        public void InsertGraph(TEntity entity)
        {            
            _dbSet.Add(entity);
        }

        public void InsertGraphRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }
        public void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
        }

        public IQueryFluentAsync<TEntity> Query()
        {
            return new QueryFluent<TEntity>(this);
        }

        public IQueryFluentAsync<TEntity> Query(Expression<Func<TEntity, bool>> query)
        {
            return new QueryFluent<TEntity>(this, query);
        }

        public IQueryFluentAsync<TEntity> Query(IQueryObject<TEntity> queryObject)
        {
            return new QueryFluent<TEntity>(this, queryObject);
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbSet;
        }

        public IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        {
            return _dbSet.SqlQuery(query, parameters).AsQueryable();
        }

        public IEnumerable<TResult> SelectQuery<TResult>(string query, params KeyValuePair<string, object>[] parameters)
        {
            var sqlParams = parameters.Select(x => _context.Database.CreateParameter(x.Key, x.Value)).ToArray();
            return _context.Database.SqlQuery<TResult>(query, sqlParams);
        }

        public void Update(TEntity entityToUpdate)
        {
            entityToUpdate.UpdateDate = DateTime.Now;
            if (!_dbSet.Local.Contains(entityToUpdate))
            {
                _dbSet.Attach(entityToUpdate);
            }
            _context.SyncObjectState(entityToUpdate, ObjectState.Modified);
        }

        public void Update(TEntity entityToUpdate,params Expression<Func<TEntity, object>>[] properties)
        {
            entityToUpdate.UpdateDate = DateTime.Now;
            if (!_dbSet.Local.Contains(entityToUpdate))
            {
                _dbSet.Attach(entityToUpdate);
            }
            //_context.SyncObjectState(entityToUpdate, ObjectState.Unchanged);
            foreach (var property in properties)
            {
                var propertyName = LambdaExpressionExtension.GetPropertyName(property);
                _context.SyncObjectState(entityToUpdate, propertyName, true);
            }
            _context.SyncObjectState(entityToUpdate, nameof(entityToUpdate.UpdateDate), true);
            _context.SyncObjectState(entityToUpdate, nameof(entityToUpdate.UpdaterUser), true);
            _context.SyncObjectState(entityToUpdate, nameof(entityToUpdate.UpdaterIpAddress), true);
        }

        #region Internal Methods
        internal IQueryable<TEntity> Select(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           List<Expression<Func<TEntity, object>>> includes = null,
           int? page = null,
           int? pageSize = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (filter != null)
            {
                query = query.AsExpandable().Where(filter);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            return query;
        }
        internal async Task<IEnumerable<TEntity>> SelectAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null)
        {
            return await Select(filter, orderBy, includes, page, pageSize).ToListAsync();
        }
        #endregion

        private void PhysicalDelete(TEntity entity)
        {

            if (!_dbSet.Local.Contains(entity))
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            
        }
    }
}
