using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SICO.Domain.Core.Repositories
{
    public interface IDataContextAsync : IDataContext
    {
        Task PerformBulkUpdateAsync<T>(IEnumerable<T> entities) where T : class;
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesWithoutValidationAsync();
        Task<int> SaveChangesWithoutValidationAsync(CancellationToken cancellationToken);
    }
}
