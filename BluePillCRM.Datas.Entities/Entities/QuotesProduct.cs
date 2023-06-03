using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.DbContext;

public partial class QuotesProduct
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

    public string? Description { get; set; }

    public int? UpdatedBy { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Quote Quote { get; set; } = null!;

    public virtual Taxis Taxes { get; set; } = null!;
}
