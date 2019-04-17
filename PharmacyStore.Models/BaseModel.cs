using System;
using Common.Mongo.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PharmacyStore.Models
{
    public class BaseModel : IBaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }       
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CreatedOnInt { get; set; }
        public int ModifiedOnInt { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}