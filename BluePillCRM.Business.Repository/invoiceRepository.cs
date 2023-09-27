using BluePillCRM.Datas;
using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Repository
{
	public class InvoiceRepository : GenericRepository<Invoice>
	{
		public InvoiceRepository(BluePillCRMDbContext bluePillCRMDbContext) : base(bluePillCRMDbContext)
        {
		}
	}
}

