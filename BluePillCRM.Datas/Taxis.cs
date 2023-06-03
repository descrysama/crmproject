using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.DbContext;

public partial class Taxis
{
    public int Id { get; set; }

    public float Percentage { get; set; }

    public virtual Quote? Quote { get; set; }

    public virtual QuotesProduct? QuotesProduct { get; set; }
}
