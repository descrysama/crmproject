using System;
using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
	public class QuoteEntityToDto
	{
        public static ReadQuote ReadQuoteMapper(Quote readQuote)
        {
            ReadQuote read = new ReadQuote
            {
                Id = readQuote.Id,
                QuoteNumber = readQuote.QuoteNumber,
                AccountId = readQuote.AccountId,
                TransactionCurency = readQuote.TransactionCurency,
                TotalWithoutTaxWithDiscount = readQuote.TotalWithoutTaxWithDiscount,
                TotalTaxAmount = readQuote.TotalTaxAmount,
                TotalWithTaxWithDiscount = readQuote.TotalWithTaxWithDiscount,
                Total = readQuote.Total,
                QuoteStatus = readQuote.QuoteStatus,
                ContactId = readQuote.ContactId != 0 ? readQuote.ContactId : 0,
                SendMethod = readQuote.SendMethod != null ? readQuote.SendMethod.Name : null,
                EmailSendTo = readQuote.EmailSendTo != 0 ? readQuote.EmailSendTo : 0,
                TaxAmount = readQuote.Taxes != null ? readQuote.Taxes.Percentage : 0,
                PaymentMethod = readQuote.PaymentMethodNavigation != null ? readQuote.PaymentMethodNavigation.Name : null,
                Description = readQuote.Description,
                AccessLevel = readQuote.AccessLevel,
                CreatedAt = readQuote.CreatedAt,
                CreatedBy = readQuote.CreatedByNavigation != null ? UserEntityToDto.ReadUserMapper(readQuote.CreatedByNavigation) : null,
                UpdatedAt = readQuote.UpdatedAt != null ? readQuote.UpdatedAt : null,
                UpdatedBy = readQuote.UpdatedByNavigation != null ? UserEntityToDto.ReadUserMapper(readQuote.UpdatedByNavigation) : null,
            };
            return read;
        }
    }
}

