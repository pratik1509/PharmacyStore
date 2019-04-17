namespace Common.Persistence.PaymentManagement.PaymentDto
{
    public class ChargeCustomerDto
    {
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string SourceId { get; set; }
        public string TransferGroupId { get; set; } //to group bunch of collection, send null if not required
        public bool IsCaptureImmediately { get; set; } = false; //payment will be captured as soon as charge
        public string CustomerStatementText { get; set; } //must be less than 22 char and should not include <>"' characters
    }
}
