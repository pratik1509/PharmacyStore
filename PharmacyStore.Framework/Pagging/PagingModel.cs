using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyStore.Framework.Pagging
{
    public class PagingModel
    {
        public PagingModel()
        {
            Page = 1;
            PageSize = 10;
        }
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
