using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.DbContext;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string? SerialNumber { get; set; }

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public bool IsDisabled { get; set; }

    public int? UpdatedBy { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<QuotesProduct> QuotesProducts { get; set; } = new List<QuotesProduct>();

    public virtual User? UpdatedByNavigation { get; set; }
}
