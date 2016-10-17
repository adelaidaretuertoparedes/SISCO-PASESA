using System.Collections.Generic;
using System.Linq;

namespace SICO.Domain.Core.Paged
{
    public class PagedList<T> : BasePagedList<T>
    {
        public PagedList(IEnumerable<T> superset, int pageNumber, int pageSize, int totalItemCount) : base(pageNumber, pageSize, totalItemCount)
        {
            Subset = superset.ToList();
        }
    }
}
