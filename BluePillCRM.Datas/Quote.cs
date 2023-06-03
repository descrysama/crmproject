using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.DbContext;

public partial class Quote
{
    public int Id { get; set; }

    public string QuoteNumber { get; set; } = null!;

    public int AccountId { get; set; }

    public string TransactionCurency { get; set; } = null!;

    public int? ContactId { get; set; }

    public int? SendMethodId { get; set; }

    public int? EmailSendTo { get; set; }

    public DateTime? SendQuoteDate { get; set; }

    public int TaxesId { get; set; }

    public int Payment { get; set; }

    public decimal TotalWithoutTaxWithDiscount { get; set; }

    public decimal TotalTaxAmount { get; set; }

    public int TotalWithTaxWithDiscount { get; set; }

    public string? Description { get; set; }

    public bool QuoteStatus { get; set; }

    public int AccessLevel { get; set; }

    public DateTime? UpdatedBy { get; set; }

    public DateTime CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User AccessLevelNavigation { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;

    public virtual Contact? Contact { get; set; }

    public virtual Taxis IdNavigation { get; set; } = null!;

    public virtual PaymentMethod PaymentNavigation { get; set; } = null!;

    public virtual ICollection<QuotesProduct> QuotesProducts { get; set; } = new List<QuotesProduct>();
}
