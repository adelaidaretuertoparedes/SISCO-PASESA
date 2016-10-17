using System;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using System.Data.Entity.Core.Objects;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using Autofac;
using SICO.Domain.Core.UnitOfWorks;
using SICO.Domain.Core.Repositories;

namespace SICO.Infrastructure.Data.Core
{
    public class UnitOfWork : IUnitOfWorkAsync
    {
        #region Members fields 
        private readonly IComponentContext _componentContext;
        private readonly Dictionary<string, dynamic> _repositories;
        private IDataContextAsync _dataContext;
        private bool _disposed;
        private ObjectContext _objectContext;
        private DbTransaction _transaction;        
        #endregion

        public UnitOfWork(IDataContextAsync dataContext,IComponentContext componentContext)
        {
            _dataContext = dataContext;
            _componentContext = componentContext;            
            _repositories = new Dictionary<string, dynamic>();
        }
       
        public IDbTransaction Transaction
        {
            get
            {
                return _transaction;
            }
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            _objectContext = ((IObjectContextAdapter)_dataContext).ObjectContext;
            if (_objectContext.Connection.State != ConnectionState.Open)
            {
                _objectContext.Connection.Open();
            }
            _transaction = _objectContext.Connection.BeginTransaction(isolationLevel);
        }

        public bool Commit()
        {
            _transaction.Commit();
            return true;
        }
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_componentContext != null)
            {
                return Resolve<IRepository<TEntity>>();
            }
            return RepositoryAsync<TEntity>();
        }

        public IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class
        {
            if (_componentContext != null)
            {
                return Resolve<IRepositoryAsync<TEntity>>();
            }
            var type = typeof(TEntity).Name;
            if (_repositories.ContainsKey(type))
            {
                return (IRepositoryAsync<TEntity>)_repositories[type];
            }
            var repositoryType = typeof(Repository<>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dataContext, this));
            return _repositories[type];
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
        public int SaveChanges(bool isDisableValidation = false)
        {
            return isDisableValidation ? _dataContext.SaveChangesWithoutValidation() : _dataContext.SaveChanges();
        }
        public async Task<int> SaveChangesAsync(bool isDisableValidation = false)
        {
            return await (isDisableValidation ? _dataContext.SaveChangesWithoutValidationAsync() : _dataContext.SaveChangesAsync());
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken, bool isDisableValidation = false)
        {
            return await (isDisableValidation ? _dataContext.SaveChangesWithoutValidationAsync(cancellationToken) : _dataContext.SaveChangesAsync(cancellationToken));
        }
        private TRepository Resolve<TRepository>() where TRepository : class
        {
            return _componentContext.ResolveOptional<TRepository>();
        }

        #region Disposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // free other managed objects that implement
                // IDisposable only
                try
                {
                    if (_objectContext != null && _objectContext.Connection.State == ConnectionState.Open)
                    {
                        _objectContext.Connection.Close();
                    }
                }
                catch (ObjectDisposedException)
                {
                    // do nothing, the objectContext has already been disposed
                }
                if (_dataContext != null)
                {
                    _dataContext.Dispose();
                    _dataContext = null;
                }
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
            // release any unmanaged objects
            // set the object references to null
            _disposed = true;
        }
        #endregion
    }
}
