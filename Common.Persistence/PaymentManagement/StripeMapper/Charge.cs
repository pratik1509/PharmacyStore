using Common.Persistence.PaymentManagement.PaymentDto;
using Stripe;

namespace Common.Persistence.PaymentManagement.StripeMapper
{
    public static class ChargeMapper
    {
        public static ChargeResultDto MapChargeToChargeResultDto(Charge charge)
        {
            return new ChargeResultDto
            {
                IsSuccess = true,
                Success = new ChargeSuccessDto
                {
                    ChargeId = charge.Id,
                    RequestId = charge.StripeResponse?.RequestId,
                    RefId = charge.BalanceTransactionId,
                    Created = charge.Created,
                    RequestDate = charge.StripeResponse?.RequestDate,
                    Status = charge.Status,
                    ResponseObject = charge.StripeResponse?.ResponseJson
                }
            };
        }

        public static ChargeResultDto MapChargeErrorToChargeResultDto(Stripe.StripeException ex)
        {
            return new ChargeResultDto
            {
                IsSuccess = false,
                Error = new ChargeErrorDto()
                {
                    ChargeId = ex.StripeError.ChargeId,
                    Code = ex.StripeError.Code,
                    DeclineCode = ex.StripeError.DeclineCode,
                    Error = ex.StripeError.Error,
                    ErrorDescription = ex.StripeError.ErrorDescription,
                    ErrorType = ex.StripeError.ErrorType,
                    Message = ex.StripeError.Message,
                    Parameter = ex.StripeError.Parameter
                }
            };
        }
    }
}
