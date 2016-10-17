using System.Collections.Generic;

namespace SICO.Application.Core
{
    public class PaginationDto<T>
    {
        public PaginationDto()
        {
            Data = new List<T>();
        }
        public PaginationDto(IEnumerable<T> superset,
            int pageSize,
            int currentPage,
            int  pageCount,
            int totalItemCount)
        {
            Data = superset;
            PageSize = pageSize;
            CurrentPage = currentPage;
            PageCount = pageCount;
            TotalItemCount = totalItemCount;

        }
        public int PageSize { get; internal set; }

        public int CurrentPage { get; internal set; }

        public int PageCount { get; internal set; }

        public int TotalItemCount { get; internal set; }

        public IEnumerable<T> Data { get; private set; }
    }
}
