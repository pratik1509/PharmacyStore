using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyStore.Web.DoctorVm.ViewModels
{
    public class AddUpdateDoctorVm
    {
        public string DoctorName { get; set; }
        public string Address { get; set; }
    }

    public class AddUpdateDoctorVmValidator : AbstractValidator<AddUpdateDoctorVm>
    {
        public AddUpdateDoctorVmValidator()
        {
            RuleFor(x => x.DoctorName).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}
