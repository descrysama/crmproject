using System;
using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class QuoteProductEntityToDto
    {
        public static readQuoteProduct readQuoteProductMapper(QuotesProduct quoteProduct)
        {
            return new readQuoteProduct()
            {
                Id = quoteProduct.Id,

                QuoteId = quoteProduct.QuoteId,

                ProductId = quoteProduct.ProductId != null ? quoteProduct.ProductId : 0,

                OutOfCatalogProduct = quoteProduct.OutOfCatalogProduct != null ? quoteProduct.OutOfCatalogProduct : null,

                TaxesId = quoteProduct.TaxesId != null ? quoteProduct.TaxesId : 0,

                TotalAmountWithoutTax = quoteProduct.TotalAmountWithoutTax != 0 ? quoteProduct.TotalAmountWithoutTax : null,

                DiscountPercentage = quoteProduct.DiscountPercentage != 0 ? quoteProduct.DiscountPercentage : 0,

                TotalAmountWithoutTaxWithDiscount = quoteProduct.TotalAmountWithoutTaxWithDiscount != 0 ? quoteProduct.TotalAmountWithoutTaxWithDiscount : 0,

                TotalTaxAmount = quoteProduct.TotalTaxAmount != 0 ? quoteProduct.TotalTaxAmount : 0,

                TotalAmountWithTaxWithDiscount = quoteProduct.TotalAmountWithTaxWithDiscount != 0 ? quoteProduct.TotalAmountWithTaxWithDiscount : 0,

                Quantity = quoteProduct.Quantity,

                Description = quoteProduct.Description != null ? quoteProduct.Description : null,

            };
        }
    }
}

