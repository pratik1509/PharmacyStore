using Common.Mongo.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PharmacyStore.Models
{
    [CollectionName("WholeSellers")]
    public class WholeSeller : BaseModel {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
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