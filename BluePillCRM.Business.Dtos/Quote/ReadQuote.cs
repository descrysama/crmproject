using System;
using BluePillCRM.Datas.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BluePillCRM.Business.Dtos
{
	public class ReadQuote
    {
        public int Id { get; set; }

        public string QuoteNumber { get; set; } = null!;

        public int AccountId { get; set; }

        public string TransactionCurency { get; set; } = null!;

        public int? ContactId { get; set; }

        public string SendMethod { get; set; } = null!;

        public int? EmailSendTo { get; set; }

        public DateTime? SendQuoteDate { get; set; }

        public float TaxAmount { get; set; }

        public string PaymentMethod { get; set; } = null!;

        public decimal Total { get; set; }

        public decimal TotalWithoutTaxWithDiscount { get; set; }

        public decimal TotalTaxAmount { get; set; }

        public decimal TotalWithTaxWithDiscount { get; set; }

        public string? Description { get; set; }

        public bool QuoteStatus { get; set; }

        public int AccessLevel { get; set; }

        public readUser? UpdatedBy { get; set; }

        public readUser CreatedBy { get; set; } = null!;

        public DateTime? UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

