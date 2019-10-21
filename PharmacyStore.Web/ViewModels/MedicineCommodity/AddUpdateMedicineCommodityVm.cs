using FluentValidation;

namespace PharmacyStore.Web.ViewModels.MedicineCommodity
{
    public class AddUpdateMedicineCommodityVm
    {
        public string Id { get; set; }
        public string Commodity { get; set; }
    }

    public class AddUpdateMedicineCommodityVmValidator : AbstractValidator<AddUpdateMedicineCommodityVm>
    {
        public AddUpdateMedicineCommodityVmValidator()
        {
            RuleFor(x => x.Commodity).NotEmpty();
        }
    }
}
