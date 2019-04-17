using System;

namespace Common.Persistence.PaymentManagement.PaymentDto
{
    public class ChargeSuccessDto
    {
        public string ChargeId { get; set; }
        public string RefId { get; set; }
        public string RequestId { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime Created { get; set; }
        public string Status { get; set; }
        public string ResponseObject { get; set; }
    }
}
