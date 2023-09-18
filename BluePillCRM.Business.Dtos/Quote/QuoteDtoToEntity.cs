using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
	public class QuoteDtoToEntity
	{
		public static Quote CreateQuoteMapper(CreateQuote createQuote, int userId)
		{
			return new Quote
			{
				QuoteNumber = Guid.NewGuid().ToString(),
				AccountId = createQuote.AccountId,
				TransactionCurency = createQuote.TransactionCurency,
				ContactId = createQuote.ContactId != 0 ? createQuote.ContactId : 0,
				SendMethodId = createQuote.SendMethodId != 0 ? createQuote.SendMethodId : 0,
				EmailSendTo = createQuote.EmailSendTo != 0 ? createQuote.EmailSendTo : 0,
				TaxesId = createQuote.TaxesId,
				PaymentMethod = createQuote.PaymentMethod,
				Description = createQuote.Description,
				AccessLevel = createQuote.AccessLevel,
				CreatedBy = userId
            };
		}

    }
}

