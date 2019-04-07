namespace PharmacyStore.Models
{
    public class WholeSeller : BaseModel {
        public string Name { get; set; }
        public string Address { get; set; }
        public string VATNo { get; set; }
        public string CSTNo { get; set; }
        public string DrugLicenseNo { get; set; }
        public string TINNo { get; set; }
        public string GSTINNo { get; set; }
        public string ContactPersonNo { get; set; }
    }
}