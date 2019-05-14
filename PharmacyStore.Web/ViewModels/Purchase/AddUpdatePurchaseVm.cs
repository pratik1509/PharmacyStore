using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using PharmacyStore.Models;
using static PharmacyStore.Services.dto.PurchaseDto.AddUpdatePurchaseDto;

namespace PharmacyStore.Web.ViewModels.Purchase
{
    public class AddUpdatePurchaseVm
    {
        public string WholeSellerId { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceValue { get; set; }
        public string InvoiceDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string LastPaymentDate { get; set; } //stores last payment date only, overwrite earlier payment date
        public string ChequeNo { get; set; }
        public string ChequeDate { get; set; }
        public double ChequeAmount { get; set; }
        public double PaidInCash { get; set; }
        public string ExtraNote { get; set; }
        public List<AddOrUpdatePurchaseMedicineDto> Medicines { get; set; }

    }

    #region Validator

    public class AddUpdatePurchaseVmValidator : AbstractValidator<AddUpdatePurchaseVm>
    {
        public AddUpdatePurchaseVmValidator()
        {
            RuleFor(x => x.InvoiceNo).NotEmpty();
            RuleFor(x => x.InvoiceValue).NotEmpty();
            RuleFor(x => x.InvoiceDate).NotEmpty();
            RuleFor(x => x.PaymentStatus).NotEmpty();
            RuleFor(x => x.LastPaymentDate).NotEmpty();
            RuleFor(x => x.ChequeNo).NotEmpty();
            RuleFor(x => x.ChequeDate).NotEmpty();
            RuleFor(x => x.ChequeAmount).NotEmpty();
            RuleFor(x => x.PaidInCash).NotEmpty();
            RuleFor(x => x.ExtraNote).NotEmpty();
            RuleFor(x => x.Medicines).NotEmpty();
            RuleForEach(x => x.Medicines).SetValidator(x => new AddOrUpdatePurchaseMedicineDtoValidator()).When(x => x.Medicines != null && x.Medicines.Any());
        }
    }

    public class AddOrUpdatePurchaseMedicineDtoValidator : AbstractValidator<AddOrUpdatePurchaseMedicineDto>
    {
        public AddOrUpdatePurchaseMedicineDtoValidator()
        {
            RuleFor(x => x.MedicineId).NotEmpty();
            //TODO Add later
        }
    }

    #endregion
}
