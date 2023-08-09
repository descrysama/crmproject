using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class readAccount
    {
        public int Id { get; set; }

        public string CompanyName { get; set; } = null!;

        public string? Siret { get; set; }

        public string? MainEmail { get; set; }

        public string? PhoneNumber { get; set; }

        public string? TvaNumber { get; set; }

        public string? WebsiteUrl { get; set; }

        public int? AccountType { get; set; }

        public int AccessLevel { get; set; }

        public readUser CreatedBy { get; set; }

        public int? PaymentMethodId { get; set; }

        public readUser OwnedBy { get; set; }

        public int LastModifiedBy { get; set; }

        public readAddress BillingAddress { get; set; } = null!;

        public readAddress DeliveryAddress { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string? Description { get; set; }
    }
}

