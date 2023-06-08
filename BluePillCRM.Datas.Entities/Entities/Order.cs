using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.Entities;

public partial class Order
{
    public int Id { get; set; }

    public string OrderNumber { get; set; } = null!;

    public int QuoteId { get; set; }

    public int? AccountId { get; set; }

    public string TransactionCurrency { get; set; } = null!;

    public int? ContactId { get; set; }

    public int? SendMethodId { get; set; }

    public string? EmailToSendAt { get; set; }

    public DateTime? OrderDate { get; set; }

    public int TaxesId { get; set; }

    public int PaymentMethod { get; set; }

    public decimal TotalAmountWithoutTax { get; set; }

    public float DiscountPercentage { get; set; }

    public decimal TotalAmountWithoutTaxWithDiscount { get; set; }

    public decimal TotalTaxAmount { get; set; }

    public decimal TotalAmountWithTaxWithDiscount { get; set; }

    public string Description { get; set; } = null!;

    public int AccessLevel { get; set; }

    public bool OrderStatus { get; set; }

    public int? ModifiedBy { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Role AccessLevelNavigation { get; set; } = null!;

    public virtual Account? Account { get; set; }

    public virtual Contact? Contact { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual PaymentMethod PaymentMethodNavigation { get; set; } = null!;

    public virtual Quote Quote { get; set; } = null!;

    public virtual SendMethod? SendMethod { get; set; }

    public virtual Taxis Taxes { get; set; } = null!;
}
