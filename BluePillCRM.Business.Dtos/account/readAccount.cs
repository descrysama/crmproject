using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string? Description { get; set; }
    }
}

