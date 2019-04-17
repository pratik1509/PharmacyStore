using Common.Persistence.PaymentManagement.PaymentDto;
using Stripe;
using System.Collections.Generic;

namespace Common.Persistence.PaymentManagement.StripeMapper
{
    public static class CustomerMapper
    {
        public static CustomerDto MapCustomerToCustomerDto(Customer customer)
        {
            return new CustomerDto {
                Id = customer.Id,
                Email = customer.Email,
                DefaultSourceId = customer.DefaultSourceId,
                MetaData = customer.Metadata,
                IsDeleted = customer.Deleted ?? false,
                Currency = customer.Currency,
                CreatedOn = customer.Created
            };
        }

        public static List<CustomerDto> MapCustomerListToCustomerDtoList(List<Customer> customers)
        {
            List<CustomerDto> customerDtoLst = new List<CustomerDto>();

            if (customers != null && customers.Count > 0)
            {
                foreach (var customer in customers)
                {
                    customerDtoLst.Add(MapCustomerToCustomerDto(customer));
                }
            }

            return customerDtoLst;
        }
    }
}
