using Common.Persistence.LogManagement;
using Common.Persistence.PaymentManagement.PaymentDto;
using Common.Persistence.PaymentManagement.StripeMapper;
using Microsoft.Extensions.Options;
using Stripe;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Persistence.PaymentManagement
{
    public class StripePaymentService : IPaymentService
    {
        private readonly string _apiKey;
        private readonly string _currency;
        private readonly StripeSettings _settings;

        public StripePaymentService(StripeSettings settings)
        {
            _settings = settings;
            _apiKey = _settings.ApiKey;
            _currency = _settings.Currency;
            StripeConfiguration.SetApiKey(_apiKey);
        }

        #region Customer

        /// <summary>
        /// get customer detail from stripe
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<CustomerDto> GetCustomer(GetCustomerDto dto)
        {
            var service = new CustomerService();
            return CustomerMapper.MapCustomerToCustomerDto(
                await service.GetAsync(dto.CustomerId));
        }

        /// <summary>
        /// get customer detail from stripe
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<List<CustomerDto>> GetAllCustomers(GetAllCustomersDto dto)
        {
            var service = new CustomerService();
            var options = new CustomerListOptions
            {
                Limit = dto.Limit,
            };

            var allCustomers = await service.ListAsync(options);

            //converting stripeList to List and mapping to dto
            return CustomerMapper.MapCustomerListToCustomerDtoList(allCustomers.Data);
        }

        /// <summary>
        /// create customer in stripe database
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<CustomerDto> CreateCustomer(CreateCustomerDto dto)
        {
            CustomerDto stripeCustomer = new CustomerDto();

            var options = new CustomerCreateOptions
            {   
                Description = dto.Description,
                SourceToken = dto.SourceToken,
                Email = dto.Email                
            };

            //adding metadata
            options.Metadata = new Dictionary<string, string>();
            options.Metadata["CustomerId"] = dto.CustomerId;

            var service = new CustomerService();
            return CustomerMapper.MapCustomerToCustomerDto(
                await service.CreateAsync(options));
        }

        /// <summary>
        /// Update information in stripe database
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<CustomerDto> UpdateCustomer(UpdateCustomerDto dto)
        {
            var options = new CustomerUpdateOptions
            {
                Description = dto.Description,
                SourceToken = dto.SourceToken,
                Email = dto.Email
            };

            var service = new CustomerService();
            return CustomerMapper.MapCustomerToCustomerDto(
                await service.UpdateAsync(dto.CustomerId, options));
        }

        /// <summary>
        /// Delete customer's information from stripe db
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<CustomerDto> DeleteCustomer(DeleteCustomerDto dto)
        {
            var service = new CustomerService();
            return CustomerMapper.MapCustomerToCustomerDto(
                await service.DeleteAsync(dto.CustomerId));
        }
                
        /// <summary>
        /// create a charge
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ChargeResultDto> ChargeCustomer(ChargeCustomerDto dto)
        {
            try
            {
                var options = new ChargeCreateOptions
                {
                    Amount = (long)(dto.Amount * 100),
                    Currency = _currency,
                    Description = dto.Description,
                    SourceId = dto.SourceId,
                    CustomerId = dto.CustomerId,
                    TransferGroup = dto.TransferGroupId,
                    Capture = dto.IsCaptureImmediately,
                    StatementDescriptor = dto.CustomerStatementText                    
                };

                //adding meta data for charge
                options.Metadata = new Dictionary<string, string>();
                options.Metadata["OrderNumber"] = dto.OrderId;
                
                var service = new ChargeService();
                return ChargeMapper.MapChargeToChargeResultDto(
                    await service.CreateAsync(options));
            }
            catch (StripeException ex)
            {
                return ChargeMapper.MapChargeErrorToChargeResultDto(ex);
            }
        }

        #endregion

        #region card

        /// <summary>
        /// discarded, this method is not required because as of now we are using vue stripe component
        /// it will be updated if required for other project in future
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<CardDto> CreateCard(CreateCardDto dto)
        {
            var cardOptions = new CardCreateOptions()
            {
                SourceToken = dto.SourceToken
            };

            var cardService = new CardService();
            return CardMapper.MapCardToCardDto(await
                cardService.CreateAsync(dto.CustomerId, cardOptions));
        }
        
        /// <summary>
        /// To delete existing card
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> DeleteCard(DeleteCardDto dto)
        {
            var service = new CardService();
            var res = await service.DeleteAsync(dto.CustomerId, dto.CardId);
            return res.Deleted;
        }
        
        /// <summary>
        /// get list of cards associated with a customer
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<List<CardDto>> ListAllCard(ListAllCardsDto dto)
        {
            var service = new CardService();
            var options = new CardListOptions
            {
                Limit = dto.CardsLimit
            };
            var cards = await service.ListAsync(dto.CustomerId, options);
            return CardMapper.MapCardListToCardDtoList(cards.Data);
        }

        /// <summary>
        /// set default card for a customer
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<CustomerDto> SetDefaultCard(SetDefaultCardDto dto)
        {
            var customerOptions = new CustomerUpdateOptions()
            {
                DefaultSource = dto.CardId
            };

            var customerService = new CustomerService();
            return CustomerMapper.MapCustomerToCustomerDto(
                await customerService.UpdateAsync(dto.customerId, customerOptions));
        }

        #endregion

        #region refund

        public async Task<RefundDto> CreateRefund(RefundCreateDto dto)
        {
            var options = new RefundCreateOptions
            {
                ChargeId = dto.ChargeId,                
                Amount = dto.Amount,
                Reason = RefundReasons.Fraudulent
            };
            var service = new RefundService();
            return RefundMapper.MapRefundToRefundDto(await service.CreateAsync(options));
        }

        #endregion
    }
}
