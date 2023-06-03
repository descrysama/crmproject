using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.DbContext;

public partial class Invoice
{
    public int Id { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public int OrdersId { get; set; }

    public int? AccountId { get; set; }

    public string TransactionCurrency { get; set; } = null!;

    public int? ContactId { get; set; }

    public int SendMethodId { get; set; }

    public string EmailToSendAt { get; set; } = null!;

    public DateTime? InvoiceDate { get; set; }

    public int PaymentMethod { get; set; }

    public decimal TotalAmountWithoutTax { get; set; }

    public decimal DiscountPercentage { get; set; }

    public decimal TotalAmountWithoutTaxWithDiscount { get; set; }

    public decimal TotalTaxAmount { get; set; }

    public decimal TotalAmountWithTaxWithDiscount { get; set; }

    public string Description { get; set; } = null!;

    public int AccessLevel { get; set; }

    public bool InvoiceStatus { get; set; }

    public int UpdatedBy { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedAt { get; set; }

    public int CreatedAt { get; set; }

    public virtual Role AccessLevelNavigation { get; set; } = null!;

    public virtual Account? Account { get; set; }

    public virtual Contact? Contact { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Order Orders { get; set; } = null!;

    public virtual PaymentMethod PaymentMethodNavigation { get; set; } = null!;

    public virtual SendMethod SendMethod { get; set; } = null!;

    public virtual User UpdatedByNavigation { get; set; } = null!;
}
