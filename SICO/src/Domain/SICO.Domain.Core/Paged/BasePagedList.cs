using System;
using System.Collections.Generic;
using System.Collections;

namespace SICO.Domain.Core.Paged
{
    public abstract class BasePagedList<T> : PagedListMetaData, IPagedList<T>
    {
        protected internal BasePagedList(int pageNumber, int pageSize, int totalItemCount)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(string.Format("pageNumber = {0}. PageNumber cannot be below 1.", pageNumber));
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(string.Format("pageSize = {0}. PageSize cannot be less than 1.", pageSize));

            // set source to blank list if superset is null to prevent exceptions
            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public int Count
        {
            get { return Subset.Count; }
        }

        protected List<T> Subset { get; set; }

        public T this[int index]
        {
            get { return Subset[index]; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Subset.GetEnumerator();
        }

        public IPagedList GetMetaData()
        {
            return new PagedListMetaData(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
