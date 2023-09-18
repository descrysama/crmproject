using BluePillCRM.Business.Dtos;

namespace BluePillCRM.Business.Dtos
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
    }
}

