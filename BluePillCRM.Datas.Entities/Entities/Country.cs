using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.DbContext;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string CountryCode { get; set; } = null!;
}
