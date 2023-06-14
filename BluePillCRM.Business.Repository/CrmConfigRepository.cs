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
                CrmConfig config = new CrmConfig();
                config.Id = 1;
                config.MaxUsers = 0;
                config.MaxAccounts = 0;
                config.MaxContacts = 0;
                config.MonthlyCost = 0;
                config.Title = "none";
                config.RoleId = 1;
                return config;
            }

            return element;
        }
    }
}
