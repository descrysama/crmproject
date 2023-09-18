using BluePillCRM.Datas;
using BluePillCRM.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace BluePillCRM.Business.Repository
{
	public class QuoteProductRepository : GenericRepository<QuotesProduct>
    {
		public QuoteProductRepository(BluePillCRMDbContext bluePillCRMDbContext) : base(bluePillCRMDbContext)
		{
		}
	}
}

