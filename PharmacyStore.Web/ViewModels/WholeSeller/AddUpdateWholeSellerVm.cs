using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace PharmacyStore.Web.ViewModels.WholeSeller
{
    public class AddUpdateWholeSellerVm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string VATNo { get; set; }
        public string CSTNo { get; set; }
        public string DrugLicenseNo { get; set; }
        public string TINNo { get; set; }
        public string GSTINNo { get; set; }
        public string ContactPersonNo { get; set; }

    }

    public class AddUpdateWholeSellerVmValidator : AbstractValidator<AddUpdateWholeSellerVm>
    {
        public AddUpdateWholeSellerVmValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.VATNo).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CSTNo).NotEmpty();
            RuleFor(x => x.DrugLicenseNo).NotEmpty();
            RuleFor(x => x.TINNo).NotEmpty();
            RuleFor(x => x.GSTINNo).NotEmpty();
            RuleFor(x => x.ContactPersonNo).NotEmpty();
        }
    }

}
