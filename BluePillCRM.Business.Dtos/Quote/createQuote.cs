using System;
using BluePillCRM.Datas.Entities;
using BluePillCRM.Business.Dtos;

namespace BluePillCRM.Business.Dtos.Quote
{
    public class CreateQuote
    {
        public int AccountId { get; set; }

        public string TransactionCurency { get; set; } = null!;

        public int? ContactId { get; set; }

        public int? SendMethodId { get; set; }

        public int? EmailSendTo { get; set; }

        public int TaxesId { get; set; }

        public int PaymentMethod { get; set; }

        public string? Description { get; set; }

        public int AccessLevel { get; set; }

        public List<AddProduct>? Products { get; set;}

        public virtual Role AccessLevelNavigation { get; set; } = null!;

        public virtual Account Account { get; set; } = null!;

        public virtual Contact? Contact { get; set; }

        public virtual User CreatedByNavigation { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual PaymentMethod PaymentMethodNavigation { get; set; } = null!;

        public virtual ICollection<QuotesProduct> QuotesProducts { get; set; } = new List<QuotesProduct>();

        public virtual SendMethod? SendMethod { get; set; }

        public virtual Taxis Taxes { get; set; } = null!;

        public virtual User? UpdatedByNavigation { get; set; }
    }
}

