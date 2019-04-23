using Common.Mongo.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PharmacyStore.Models
{
    [CollectionName("Medicines")]
    public class Medicine : BaseModel
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string ScheduleCategoryId { get; set; }
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string MedicineCategoryId { get; set; }
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
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