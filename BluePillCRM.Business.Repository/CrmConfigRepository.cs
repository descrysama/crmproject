using BluePillCRM.Datas;
using BluePillCRM.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace BluePillCRM.Business.Repository
{
    public class CrmConfigRepository
    {
        protected readonly BluePillCRMDbContext _bluePillCRMDbContext;

        protected readonly DbSet<CrmConfig> _table;
        public CrmConfigRepository(BluePillCRMDbContext bluePillCRMDbContext)
        {
            _bluePillCRMDbContext = bluePillCRMDbContext;
            _table = _bluePillCRMDbContext.Set<CrmConfig>();
        }

        public async Task<CrmConfig> GetCrmConfig(int id)
        {
            CrmConfig element = await _table.FindAsync(id).ConfigureAwait(false);

            if (element == null)
            {
                throw new Exception("Element non trouvé.");
            }

            return element;
        }
    }
}
