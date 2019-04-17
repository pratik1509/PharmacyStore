using Common.Persistence.PaymentManagement.PaymentDto;
using Stripe;

namespace Common.Persistence.PaymentManagement.StripeMapper
{
    public static class RefundMapper
    {
        public static RefundDto MapRefundToRefundDto(Refund refund)
        {
            return new RefundDto {
                RefundId = refund.Id,
                ChargeId = refund.ChargeId,
                RefundedAmount = refund.Amount,
                BalanceTransactionId = refund.BalanceTransactionId,
                MetaData = refund.Metadata,
                Reson = refund.Reason,
                Status = refund.Status
            };
        }
    }
}
