using FluentValidation;

namespace PharmacyStore.Web.Doctor.ViewModels
{
    public class AddUpdateDoctorVm
    {
        public string DoctorId { get; set; }
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
