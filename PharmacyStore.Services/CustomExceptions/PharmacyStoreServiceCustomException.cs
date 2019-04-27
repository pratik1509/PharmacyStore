using System.Net;

namespace PharmacyStore.Services.CustomExceptions
{
    public class PharmacyStoreServiceCustomException : BaseCustomException
    {
        public PharmacyStoreServiceCustomException(string message, string description)
            : base(message, description, (int)HttpStatusCode.NotFound)
        {
        }
    }
}
