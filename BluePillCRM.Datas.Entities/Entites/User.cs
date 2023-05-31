using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int Role { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
