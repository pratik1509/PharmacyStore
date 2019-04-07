using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PharmacyStore.Models
{
    public class Stock : BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MedicineId { get; set; }
        public string BatchNo { get; set; }
        public string ExpiryDate { get; set; }
        public double VAT { get; set; }
        public double IGST { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public int UnitsPerStrip { get; set; }
        public double PricePerStrip { get; set; }
        public double MRPPerStrip { get; set; }
        public double QuantityInUnits { get; set; }
    }
}