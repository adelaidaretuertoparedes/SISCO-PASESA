using SICO.Domain.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SICO.Domain.Core.UnitOfWorks
{
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<int> SaveChangesAsync(bool isDisableValidation = false);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken, bool isDisableValidation = false);
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class;
    }
}
