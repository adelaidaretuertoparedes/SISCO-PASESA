using SICO.Domain.Core.Repositories;
using System;
using System.Data;

namespace SICO.Domain.Core.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IDbTransaction Transaction
        {
            get;
        }
        int SaveChanges(bool isDisableValidation = false);
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}
