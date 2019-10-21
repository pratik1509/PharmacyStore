using FluentValidation;

namespace PharmacyStore.Web.ViewModels.ScheduledCategory
{
    public class AddUpdateScheduledCategoryVm
    {
        public string Id { get; set; }
        public string Category { get; set; }
    }

    public class AddUpdateScheduledCategoryVmValidator : AbstractValidator<AddUpdateScheduledCategoryVm>
    {
        public AddUpdateScheduledCategoryVmValidator()
        {
            RuleFor(x => x.Category).NotEmpty();
        }
    }
}
