using SICO.Domain.Core.Paged;
using SICO.Domain.Core.Repositories;
using SICO.Domain.Main.ArticleGroups;
using SICO.Domain.Main.Classifications;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SICO.Infrastructure.Data.Main.Repositories
{
    public static class ClassificationRepository
    {
        public static async Task<IPagedList<Classification>> GetClassificationsAsync(this IRepositoryAsync<Classification> repository,
             int page,
            int pageSize,
            string name = null,
            string code = null,
            int? articleGroupCode = null)
        {
            var queries = from cl in repository.Queryable().Where(x => (x.Name.Contains(name) || name == null) &&
                                 (x.Code.Contains(code) || code == null) &&
                                 (x.ArticleGroupCode == articleGroupCode || articleGroupCode == null))
                          join ag in repository.GetRepositoryAsync<ArticleGroup>().Queryable()
                          on cl.ArticleGroupCode equals ag.Code
                          select new { cl, ag };

            var rowsCount = await queries.CountAsync();

            var results = await queries
                .OrderByDescending(x => x.cl.UpdateDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync();

            foreach (var item in results)
            {
                item.cl.ArticleGroup = item.ag;
            }

            return results
                    .Select(x => x.cl)
                    .ToPagedList(page, pageSize, rowsCount);
        }
    }
}
