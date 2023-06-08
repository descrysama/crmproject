using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.Entities;

public partial class Taxis
{
    public int Id { get; set; }

    public float Percentage { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();

    public virtual ICollection<QuotesProduct> QuotesProducts { get; set; } = new List<QuotesProduct>();
}
