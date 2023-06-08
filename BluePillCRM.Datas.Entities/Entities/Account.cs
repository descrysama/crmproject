using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.Entities;

public partial class Account
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Siret { get; set; }

    public string? MainEmail { get; set; }

    public string? PhoneNumber { get; set; }

    public string? TvaNumber { get; set; }

    public string? WebsiteUrl { get; set; }

    public int? AccountType { get; set; }

    public int? PaymentMethodId { get; set; }

    public bool IsDeleted { get; set; }

    public int? DeliveryAddressId { get; set; }

    public int? BillingAddressId { get; set; }

    public int OwnerId { get; set; }

    public string? Description { get; set; }

    public int AccessLevel { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int CreatedBy { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Role AccessLevelNavigation { get; set; } = null!;

    public virtual AccountType? AccountTypeNavigation { get; set; }

    public virtual Address? BillingAddress { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Address? DeliveryAddress { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual User? LastModifiedByNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User Owner { get; set; } = null!;

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();
}
