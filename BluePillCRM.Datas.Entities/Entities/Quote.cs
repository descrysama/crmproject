using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BluePillCRM.Datas.Entities;

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

    public int? TaxesId { get; set; }

    public int PaymentMethod { get; set; }

    public decimal Total { get; set; }

    public decimal TotalWithoutTaxWithDiscount { get; set; }

    public decimal TotalTaxAmount { get; set; }

    public decimal TotalWithTaxWithDiscount { get; set; }

    public string? Description { get; set; }

    public bool QuoteStatus { get; set; }

    public int AccessLevel { get; set; }

    public int? UpdatedBy { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Role AccessLevelNavigation { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;

    public virtual Contact? Contact { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual PaymentMethod PaymentMethodNavigation { get; set; } = null!;

    public virtual ICollection<QuotesProduct> QuotesProducts { get; set; } = new List<QuotesProduct>();

    public virtual SendMethod? SendMethod { get; set; }

    public virtual Taxis? Taxes { get; set; }

    public virtual User? UpdatedByNavigation { get; set; }

    public static implicit operator Quote(EntityEntry<Quote> v)
    {
        throw new NotImplementedException();
    }
}
