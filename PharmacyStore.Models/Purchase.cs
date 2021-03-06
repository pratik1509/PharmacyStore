using System.Collections.Generic;
using Common.Mongo.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PharmacyStore.Models
{
    [CollectionName("Purchases")]
    public class Purchase : BaseModel
    {
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string wholeSellerId { get; set; }
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
    }

    public class PurchaseMedicine
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
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
}