using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyStore.Services.dto.Medicine
{
    public class AddUpdateMedicineDto
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
}
