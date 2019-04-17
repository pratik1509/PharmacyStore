using Common.Mongo.Repository;

namespace PharmacyStore.Models
{
    [CollectionName("MedicineCategories")]
    public class MedicineCategory : BaseModel
    {
        public string Category { get; set; }
    }
}