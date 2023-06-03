using System;
using System.Collections.Generic;

namespace BluePillCRM.Datas.DbContext;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Address> AddressAccessLevelNavigations { get; set; } = new List<Address>();

    public virtual ICollection<Address> AddressCreatedByNavigations { get; set; } = new List<Address>();

    public virtual ICollection<Address> AddressModifiedByNavigations { get; set; } = new List<Address>();

    public virtual ICollection<Address> AddressUsers { get; set; } = new List<Address>();

    public virtual ICollection<Contact> ContactCreatedByNavigations { get; set; } = new List<Contact>();

    public virtual ICollection<Contact> ContactModifiedByNavigations { get; set; } = new List<Contact>();

    public virtual ICollection<Contact> ContactOwners { get; set; } = new List<Contact>();

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();

    public virtual Role Role { get; set; } = null!;
}
