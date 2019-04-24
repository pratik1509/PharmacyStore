using FluentValidation;

namespace PharmacyStore.Web.ViewModels.MedicineCategory
{
    public class AddUpdateMedicineVm
    {
        public string Id { get; set; }
        public string ScheduleCategoryId { get; set; }
        public string MedicineCategoryId { get; set; }
        public string MedicineCommodityId { get; set; }
        public string Name { get; set; }
        public string GenericName { get; set; }
        public string Manufacturer { get; set; }
        public double DiscountPercentage { get; set; }
        public string HSNCode { get; set; }
        public double Price { get; set; }
        public double VAT { get; set; }
        public double AdditionalTax { get; set; }
        public double IGST { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
    }

    public class AddUpdateMedicineVmValidator : AbstractValidator<AddUpdateMedicineVm>
    {
        public AddUpdateMedicineVmValidator()
        {
            RuleFor(x => x.ScheduleCategoryId).NotEmpty();
            RuleFor(x => x.MedicineCategoryId).NotEmpty();
            RuleFor(x => x.MedicineCommodityId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.GenericName).NotEmpty();
            RuleFor(x => x.Manufacturer).NotEmpty();
            RuleFor(x => x.DiscountPercentage).NotEmpty();
            RuleFor(x => x.HSNCode).NotEmpty(); 
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.VAT).NotEmpty();
            RuleFor(x => x.AdditionalTax).NotEmpty(); 
            RuleFor(x => x.IGST).NotEmpty();
            RuleFor(x => x.CGST).NotEmpty();
            RuleFor(x => x.SGST).NotEmpty();
        }
    }
}
