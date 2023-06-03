using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.DbContext;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();
}
