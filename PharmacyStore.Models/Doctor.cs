using Common.Mongo.Repository;

namespace PharmacyStore.Models
{
    [CollectionName("Doctors")]
    public class Doctor : BaseModel {       
        public string DoctorName { get; set; }
        public string Address { get; set; }
    }
}