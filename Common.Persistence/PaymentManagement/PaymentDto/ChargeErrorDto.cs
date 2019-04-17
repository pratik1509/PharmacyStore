namespace Common.Persistence.PaymentManagement.PaymentDto
{
    public class ChargeErrorDto
    {
        public string ChargeId { get; set; }
        public string Code { get; set; }
        public string DeclineCode { get; set; }
        public string Message { get; set; }
        public string Parameter { get; set; }
        public string ErrorType { get; set; }
        public string Error { get; set; }
        public string ErrorDescription { get; set; }
    }
}
