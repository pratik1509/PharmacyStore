using Common.Persistence.PaymentManagement.PaymentDto;
using Stripe;
using System.Collections.Generic;

namespace Common.Persistence.PaymentManagement.StripeMapper
{
    public static class CardMapper
    {
        public static CardDto MapCardToCardDto(Card card)
        {
            return new CardDto()
            {
                Id = card.Id,
                DefaultForCurrency = card.DefaultForCurrency,
                DynamicLast4 = card.DynamicLast4,
                ExpirationMonth = card.ExpMonth,
                ExpirationYear = card.ExpYear,
                Fingerprint = card.Fingerprint,
                Funding = card.Funding,
                CvcCheck = card.CvcCheck,
                Last4 = card.Last4,
                Name = card.Name,
                RecipientId = card.RecipientId,
                ThreeDSecure = card.ThreeDSecure,
                TokenizationMethod = card.TokenizationMethod,
                Description = card.Description,
                Metadata = card.Metadata,
                IIN = card.IIN,
                Currency = card.Currency,
                Object = card.Object,
                AccountId = card.AccountId,
                AddressCity = card.AddressCity,
                AddressCountry = card.AddressCountry,
                AddressLine1 = card.AddressLine1,
                CustomerId = card.CustomerId,
                AddressLine1Check = card.AddressLine1Check,
                AddressState = card.AddressState,
                AddressZip = card.AddressZip,
                AddressZipCheck = card.AddressZipCheck,
                AvailablePayoutMethods = card.AvailablePayoutMethods,
                Brand = card.Brand,
                Country = card.Country,
                AddressLine2 = card.AddressLine2,
                Issuer = card.Issuer,
                IsdefaultCard = card.DefaultForCurrency
            };
        }

        public static List<CardDto> MapCardListToCardDtoList(List<Card> cards)
        {
            List<CardDto> cardsDto = new List<CardDto>();

            if(cards != null && cards.Count > 0)
            {
                foreach (var card in cards)
                {
                    cardsDto.Add(MapCardToCardDto(card));
                }
            }

            return cardsDto;
        }
    }
}
