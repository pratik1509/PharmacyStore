using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using PharmacyStore.Models;

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
        public List<PurchaseMedicine> Medicines { get; set; }


        public string MedicineId { get; set; }
        public string BatchNo { get; set; }
        public string ExpiryDate { get; set; }
        public string BoxNo { get; set; }
        public int UnitsPerStrip { get; set; }
        public int NoOfStrips { get; set; }
        public double PricePerStrip { get; set; }
        public double MRPPerStrip { get; set; }
        public int FreeStrips { get; set; }
        public double DiscountPercentage { get; set; }
        public string HSNCode { get; set; }
        public double VAT { get; set; }
        public double AdditionalTax { get; set; }
        public double IGST { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
    }

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
            RuleFor(x => x.BatchNo).NotEmpty();
            RuleFor(x => x.ExpiryDate).NotEmpty();
            RuleFor(x => x.BoxNo).NotEmpty();
            RuleFor(x => x.UnitsPerStrip).NotEmpty();
            RuleFor(x => x.NoOfStrips).NotEmpty();
            RuleFor(x => x.PricePerStrip).NotEmpty();
            RuleFor(x => x.MRPPerStrip).NotEmpty();
            RuleFor(x => x.FreeStrips).NotEmpty();
            RuleFor(x => x.DiscountPercentage).NotEmpty();
            RuleFor(x => x.HSNCode).NotEmpty();
            RuleFor(x => x.VAT).NotEmpty();
            RuleFor(x => x.AdditionalTax).NotEmpty();
            RuleFor(x => x.IGST).NotEmpty();
            RuleFor(x => x.CGST).NotEmpty();
            RuleFor(x => x.SGST).NotEmpty();
        }
    }
}
