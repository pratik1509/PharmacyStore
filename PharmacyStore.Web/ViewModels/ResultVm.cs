using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyStore.Web.ViewModels
{
    public class ResultVm<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
    }
}
