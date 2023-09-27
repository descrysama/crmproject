using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
	public class ReadInvoice
	{
        public int Id { get; set; }

        public string InvoiceNumber { get; set; } = null!;

        public int OrdersId { get; set; }

        public Account? Account { get; set; }

        public string TransactionCurrency { get; set; } = null!;

        public Contact? Contact { get; set; }

        public string? SendMethod { get; set; }

        public string EmailToSendAt { get; set; } = null!;

        public DateTime? InvoiceDate { get; set; }

        public string PaymentMethod { get; set; }

        public decimal TotalAmountWithoutTax { get; set; }

        public decimal DiscountPercentage { get; set; }

        public decimal TotalAmountWithoutTaxWithDiscount { get; set; }

        public decimal TotalTaxAmount { get; set; }

        public decimal TotalAmountWithTaxWithDiscount { get; set; }

        public string Description { get; set; } = null!;

        public int AccessLevel { get; set; }

        public bool InvoiceStatus { get; set; }

        public readUser UpdatedBy { get; set; }

        public readUser CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

