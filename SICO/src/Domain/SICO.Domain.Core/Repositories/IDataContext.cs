using System.Collections.Generic;

namespace SICO.Domain.Core.Repositories
{
    public interface IDataContext
    {
        IDatabase Database { get; }
        void PerformBulkUpdate<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void Dispose();
        int SaveChanges();
        int SaveChangesWithoutValidation();
        void SyncObjectState<TEntity>(TEntity entity, ObjectState objectState) where TEntity : class;
        void SyncObjectState<TEntity>(TEntity entity, string propertyName, bool isModified) where TEntity : class;
    }
}
