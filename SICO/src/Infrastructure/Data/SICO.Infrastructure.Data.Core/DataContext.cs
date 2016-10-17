using SICO.Domain.Core;
using SICO.Domain.Core.Repositories;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Generic;

namespace SICO.Infrastructure.Data.Core
{
    [DbConfigurationType(typeof(DbConfig))]
    public class DataContext : DbContext, IDataContextAsync
    {
        private readonly IDatabase _database;
        private bool _disposed;
        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            InstanceId = Guid.NewGuid();
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            _database = new DatabaseWrapper(Database);
            
        }
        IDatabase IDataContext.Database
        {
            get
            {
                return _database;
            }
        }
        public Guid InstanceId { get; private set; }
        public IDataParameter CreateParameter<T>(string name, T value)
        {
            
            throw new NotImplementedException();
        }
        public void PerformBulkUpdate<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            this.BulkUpdate(entities);
        }

        public async Task PerformBulkUpdateAsync<T>(IEnumerable<T> entities) where T : class
        {
            await this.BulkUpdateAsync(entities);
        }

        public int SaveChangesWithoutValidation()
        {
            Configuration.ValidateOnSaveEnabled = false;
            try
            {
                return SaveChanges();
            }
            finally
            {
                Configuration.ValidateOnSaveEnabled = true;
            }
        }
        public async Task<int> SaveChangesWithoutValidationAsync()
        {
            return await SaveChangesWithoutValidationAsync(CancellationToken.None);
        }
        public async Task<int> SaveChangesWithoutValidationAsync(CancellationToken cancellationToken)
        {
            Configuration.ValidateOnSaveEnabled = false;
            try
            {
                return await SaveChangesAsync(cancellationToken);
            }
            finally
            {
                Configuration.ValidateOnSaveEnabled = true;
            }
        }
        public void SyncObjectState<TEntity>(TEntity entity, ObjectState objectState) where TEntity : class
        {
            Entry(entity).State = StateHelper.ConvertState(objectState);
        }
        public void SyncObjectState<TEntity>(TEntity entity, string propertyName, bool isModified) where TEntity : class
        {
            Entry(entity).Property(propertyName).IsModified = isModified;
        }
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // free other managed objects that implement
                    // IDisposable only
                }
                // release any unmanaged objects
                // set object references to null
                _disposed = true;
            }
            base.Dispose(disposing);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }       
    }
}
