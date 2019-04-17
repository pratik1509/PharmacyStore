using System.Collections.Generic;

namespace Common.Persistence.PaymentManagement.PaymentDto
{
    public class RefundDto
    {
        public string RefundId { get; set; }
        public long RefundedAmount { get; set; }        
        public string BalanceTransactionId { get; set; }
        public string ChargeId { get; set; }        
        public Dictionary<string, string> MetaData { get; set; }
        public string Reson { get; set; }
        public string Status { get; set; }
    }
}
