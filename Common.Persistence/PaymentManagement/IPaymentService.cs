using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Persistence.PaymentManagement.PaymentDto;

namespace Common.Persistence.PaymentManagement
{
    public interface IPaymentService
    {
        #region Customer

        Task<List<CustomerDto>> GetAllCustomers(GetAllCustomersDto dto);
        Task<CustomerDto> GetCustomer(GetCustomerDto dto);
        Task<CustomerDto> CreateCustomer(CreateCustomerDto dto);
        Task<CustomerDto> UpdateCustomer(UpdateCustomerDto dto);
        Task<CustomerDto> DeleteCustomer(DeleteCustomerDto dto);

        #endregion

        #region card

        Task<CardDto> CreateCard(CreateCardDto dto);
        Task<bool> DeleteCard(DeleteCardDto dto);
        Task<List<CardDto>> ListAllCard(ListAllCardsDto dto);
        Task<CustomerDto> SetDefaultCard(SetDefaultCardDto dto);

        #endregion

        #region charge

        Task<ChargeResultDto> ChargeCustomer(ChargeCustomerDto dto);

        #endregion

        #region refund

        Task<RefundDto> CreateRefund(RefundCreateDto dto);

        #endregion

    }
}