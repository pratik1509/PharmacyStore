namespace Common.Persistence.PaymentManagement.PaymentDto
{
    public class CreateCardDto
    {
        public string CustomerId { get; set; }
        public string SourceToken { get; set; }
    }
}
