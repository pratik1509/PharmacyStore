using System.Collections.Generic;

namespace Common.Persistence.PaymentManagement.PaymentDto
{
    public class CardDto
    {
        public string Id { get; set; }        
        public bool DefaultForCurrency { get; set; }
        public string DynamicLast4 { get; set; }
        public long ExpirationMonth { get; set; }
        public long ExpirationYear { get; set; }
        public string Fingerprint { get; set; }
        public string Funding { get; set; }
        public string CvcCheck { get; set; }
        public string Last4 { get; set; }
        public string Name { get; set; }
        public string RecipientId { get; set; }
        public string ThreeDSecure { get; set; }
        public string TokenizationMethod { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public string IIN { get; set; }
        public string Currency { get; set; }
        public string Object { get; set; }
        public string AccountId { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public string AddressLine1 { get; set; }
        public string CustomerId { get; set; }
        public string AddressLine1Check { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
        public string AddressZipCheck { get; set; }
        public string[] AvailablePayoutMethods { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }
        public string AddressLine2 { get; set; }
        public string Issuer { get; set; }
        public bool IsdefaultCard { get; set; }
    }
}
