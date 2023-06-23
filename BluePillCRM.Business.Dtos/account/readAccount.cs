using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class readAccount
    {
        public string CompanyName { get; set; } = null!;

        public string? Siret { get; set; }

        public string? MainEmail { get; set; }

        public string? PhoneNumber { get; set; }

        public string? TvaNumber { get; set; }

        public string? WebsiteUrl { get; set; }

        public int? AccountType { get; set; }

        public int AccessLevel { get; set; }

        public int CreatedBy { get; set; }

        public int? PaymentMethodId { get; set; }

        public int OwnerId { get; set; }

        public int LastModifiedBy { get; set; }

        public Address BillingAddress { get; set; } = null!;

        public Address DeliveryAddress { get; set; } = null!;

        public List<Contact> Contacts { get; set; } = null!;

        public List<Order> Orders { get; set; } = null!;

        public List<Quote> Quotes { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string? Description { get; set; }
    }
}

