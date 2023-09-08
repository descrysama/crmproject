using System;
namespace BluePillCRM.Business.Dtos
{
	public class AddProduct
    {
		public int ProductId { get; set; } = 0;

		public int? TaxId { get; set; } = 0;

		public string? Name { get; set; }

		public decimal? Discount { get; set; } = 0;

		public int Quantity { get; set; } = 1;

		public string? Description { get; set; }
	}
}

