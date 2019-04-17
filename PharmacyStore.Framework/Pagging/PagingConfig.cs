using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyStore.Framework.Pagging
{
    internal class PagingConfig
    {
        public PagingConfig(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
