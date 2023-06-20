using BluePillCRM.Datas;
using BluePillCRM.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace BluePillCRM.Business.Repository
{
    public class AccountRepository : GenericRepository<Account>
    {

        public AccountRepository(BluePillCRMDbContext bluePillCRMDbContext) : base(bluePillCRMDbContext)
        {
        }

        public async Task<Account> FindOneByCompanyName(string companyName)
        {
            Account type = await _table.FirstOrDefaultAsync(u => u.CompanyName == companyName);
            if (type == null)
            {
                return null;
            }
            else
            {
                return type;
            }
        }

        public async Task<Account> FindOneBySiretNumber(string siretNumber)
        {
            if (siretNumber != null)
            {
                Account type = await _table.FirstOrDefaultAsync(u => u.Siret == siretNumber);
                if (type == null)
                {
                    return null;
                }
                else
                {
                    return type;
                }
            } else
            {
                return null;
            }
        }
    }
}
