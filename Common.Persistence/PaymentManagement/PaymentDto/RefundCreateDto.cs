using System.Collections.Generic;

namespace Common.Persistence.PaymentManagement.PaymentDto
{
    public class RefundCreateDto
    {
        public string ChargeId { get; set; }
        public int Amount { get; set; }
        public Dictionary<string, string> MetaData { get; set; }
        public string Reason { get; set; }
    }
}
