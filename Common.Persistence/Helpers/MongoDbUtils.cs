using MongoDB.Bson;

namespace Common.Persistence.Helpers
{
    public class MongoDbUtils
    {
        public static bool IsValidId(string userId)
        {
            ObjectId id;
            return (userId != string.Empty && ObjectId.TryParse(userId, out id));
        }
    }
}
