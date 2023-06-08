﻿using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.Entities;

public partial class AccountType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
