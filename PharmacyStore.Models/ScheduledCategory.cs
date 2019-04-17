using Common.Mongo.Repository;

namespace PharmacyStore.Models
{
    [CollectionName("ScheduledCategories")]
    public class ScheduledCategory : BaseModel {
        public string Category { get; set; }
    }
}