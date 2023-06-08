using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.Entities;

public partial class CrmConfig
{
    public int Id { get; set; }

    public int MaxUsers { get; set; }

    public int MaxAccounts { get; set; }

    public int MaxContacts { get; set; }

    public decimal MonthlyCost { get; set; }

    public string Title { get; set; } = null!;

    public int RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
