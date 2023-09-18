using System;
using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class readQuoteProduct
    {
        public int Id { get; set; }

        public int QuoteId { get; set; }

        public int? ProductId { get; set; }

        public string? OutOfCatalogProduct { get; set; }

        public int TaxesId { get; set; }

        public decimal? TotalAmountWithoutTax { get; set; }

        public decimal? DiscountPercentage { get; set; }

        public decimal? TotalAmountWithoutTaxWithDiscount { get; set; }

        public decimal? TotalTaxAmount { get; set; }

        public decimal? TotalAmountWithTaxWithDiscount { get; set; }

        public int Quantity { get; set; } = 1;

        public string? Description { get; set; }

        public string? ProductName { get; set; }

        public string? ProductCode { get; set; }

    }
}

