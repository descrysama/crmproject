using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.DbContext;

public partial class Contact
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string? Email { get; set; }

    public string? MobilePhone { get; set; }

    public string EnterprisePhone { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public bool IsDeactivated { get; set; }

    public int OwnerId { get; set; }

    public string? Description { get; set; }

    public int AccessLevel { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public int CreatedBy { get; set; }

    public virtual Role AccessLevelNavigation { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual User Owner { get; set; } = null!;

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();
}
