using System.Collections.Generic;

namespace SICO.Domain.Core.Paged
{
    public interface IPagedList<out T> : IPagedList, IEnumerable<T>
    {
        T this[int index] { get; }
        int Count { get; }
        IPagedList GetMetaData();
    }
    public interface IPagedList
    {
        int PageCount { get; }
        int PageNumber { get; }
        int PageSize { get; }
        int TotalItemCount { get; }
    }
}
