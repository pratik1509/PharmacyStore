using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyStore.Framework.Pagging
{
    public class PagingResponse
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public long TotalCount { get; set; }
    }

    public interface IPagedList<out T>
    {
        IEnumerable<T> Data { get; }
        PagingResponse Paging { get; }
    }

    public class PagedList<T> : IPagedList<T>
    {
        private int Page { get; }

        private int PageSize { get; }

        private long TotalCount { get; }


        public PagedList(IEnumerable<T> data, int page, int pageSize, long totalCount)
        {
            Data = data;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
        public IEnumerable<T> Data { get; }

        public PagingResponse Paging
        {
            get
            {
                return new PagingResponse() { Page = Page, PageSize = PageSize, TotalCount = TotalCount };
            }
        }
    }
}
