using System.Net;

namespace PharmacyStore.Services.CustomExceptions
{
    public class NotFoundCustomException : BaseCustomException
    {
        public NotFoundCustomException(string message, string description) 
            : base(message, description, (int)HttpStatusCode.NotFound)
        {
        }
    }
}
