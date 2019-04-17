using Common.Mongo.Repository;

namespace PharmacyStore.Models
{
    [CollectionName("MedicineCommodities")]
    public class MedicineCommodity : BaseModel {
        public string Commodity { get; set; }
    }
}