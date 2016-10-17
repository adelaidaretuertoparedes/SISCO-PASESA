using System.Collections.Generic;

namespace SICO.Domain.Core.Paged
{
    public static class PagedListExtensions
    {
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> superset, int pageNumber, int pageSize, int totalItemCount)
        {
            return new PagedList<T>(superset, pageNumber, pageSize, totalItemCount);
        }
    }
}
