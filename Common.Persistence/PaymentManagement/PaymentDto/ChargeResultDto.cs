namespace Common.Persistence.PaymentManagement.PaymentDto
{
    public class ChargeResultDto
    {
        public bool IsSuccess { get; set; }
        public ChargeSuccessDto Success { get; set; }
        public ChargeErrorDto Error { get; set; }
    }
}
