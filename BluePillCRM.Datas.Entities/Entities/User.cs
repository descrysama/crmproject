
namespace BluePillCRM.Datas.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Account> AccountCreatedByNavigations { get; set; } = new List<Account>();

    public virtual ICollection<Account> AccountLastModifiedByNavigations { get; set; } = new List<Account>();

    public virtual ICollection<Account> AccountOwners { get; set; } = new List<Account>();

    public virtual ICollection<Contact> ContactCreatedByNavigations { get; set; } = new List<Contact>();

    public virtual ICollection<Contact> ContactModifiedByNavigations { get; set; } = new List<Contact>();

    public virtual ICollection<Contact> ContactOwners { get; set; } = new List<Contact>();

    public virtual ICollection<Invoice> InvoiceCreatedByNavigations { get; set; } = new List<Invoice>();

    public virtual ICollection<Invoice> InvoiceUpdatedByNavigations { get; set; } = new List<Invoice>();

    public virtual ICollection<Order> OrderCreatedByNavigations { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderModifiedByNavigations { get; set; } = new List<Order>();

    public virtual ICollection<Product> ProductCreatedByNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductUpdatedByNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Quote> QuoteCreatedByNavigations { get; set; } = new List<Quote>();

    public virtual ICollection<Quote> QuoteUpdatedByNavigations { get; set; } = new List<Quote>();

    public virtual ICollection<QuotesProduct> QuotesProductCreatedByNavigations { get; set; } = new List<QuotesProduct>();

    public virtual ICollection<QuotesProduct> QuotesProductUpdatedByNavigations { get; set; } = new List<QuotesProduct>();

    public virtual Role Role { get; set; } = null!;
}
