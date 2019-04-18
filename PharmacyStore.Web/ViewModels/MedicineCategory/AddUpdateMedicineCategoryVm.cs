using FluentValidation;

namespace PharmacyStore.Web.ViewModels.MedicineCategory
{
    public class AddUpdateMedicineCategoryVm
    {
        public string Id { get; set; }
        public string Category { get; set; }
    }

    public class AddUpdateMedicineCategoryVmValidator : AbstractValidator<AddUpdateMedicineCategoryVm>
    {
        public AddUpdateMedicineCategoryVmValidator()
        {
            RuleFor(x => x.Category).NotEmpty();
        }
    }
}
