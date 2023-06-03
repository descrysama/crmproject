using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.DbContext;

public partial class Address
{
    public int Id { get; set; }

    public string Street { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string City { get; set; } = null!;

    public int CountryId { get; set; }

    public int UserId { get; set; }

    public int AccessLevel { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int ModifiedBy { get; set; }

    public int CreatedBy { get; set; }

    public virtual User AccessLevelNavigation { get; set; } = null!;

    public virtual ICollection<Account> AccountBillingAddresses { get; set; } = new List<Account>();

    public virtual ICollection<Account> AccountDeliveryAddresses { get; set; } = new List<Account>();

    public virtual Country Country { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User ModifiedByNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
