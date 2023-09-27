using System;
using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
	public class InvoiceEntityToDto
	{
        public static ReadInvoice ReadInvoiceMapper(Invoice readInvoice)
        {
            ReadInvoice read = new()
            {
                Id = readInvoice.Id,
                InvoiceNumber = readInvoice.InvoiceNumber,
                OrdersId = readInvoice.OrdersId,
                Account = readInvoice.Account,
                TransactionCurrency = readInvoice.TransactionCurrency,
                Contact = readInvoice.Contact,
                SendMethod = readInvoice.SendMethod.Name,
                EmailToSendAt = readInvoice.EmailToSendAt,
                InvoiceDate = readInvoice.InvoiceDate,
                PaymentMethod = readInvoice.PaymentMethodNavigation.Name,
                TotalAmountWithoutTax = readInvoice.TotalAmountWithoutTax,
                DiscountPercentage = readInvoice.DiscountPercentage,
                TotalAmountWithoutTaxWithDiscount = readInvoice.TotalAmountWithoutTaxWithDiscount,
                TotalTaxAmount = readInvoice.TotalTaxAmount,
                TotalAmountWithTaxWithDiscount = readInvoice.TotalAmountWithTaxWithDiscount,

            };
            return read;
        }
    }
}

