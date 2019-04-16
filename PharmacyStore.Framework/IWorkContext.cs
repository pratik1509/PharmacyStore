using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyStore.Framework
{
    public interface IWorkContext
    {
        string SiteBaseUrl { get; }
    }
}
