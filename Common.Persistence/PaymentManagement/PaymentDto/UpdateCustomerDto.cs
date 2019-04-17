namespace Common.Persistence.PaymentManagement.PaymentDto
{
    public class UpdateCustomerDto
    {
        public string CustomerId { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string SourceToken { get; set; }
    }
}
