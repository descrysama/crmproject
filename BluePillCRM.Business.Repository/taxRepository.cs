using BluePillCRM.Datas.Entities;
using BluePillCRM.Datas;

namespace BluePillCRM.Business.Repository
{
	public class TaxRepository : GenericRepository<Taxis>
	{
		public TaxRepository(BluePillCRMDbContext bluePillCRMDbContext) : base(bluePillCRMDbContext)
		{
		}
	}
}

