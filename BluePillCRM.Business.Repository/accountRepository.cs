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

        public async Task<List<Account>> GetAccountOwnedOrPublic(int id, int userRole, int getOwnOnly)
        {
            if(getOwnOnly == 1)
            {
                List<Account> accounts = await _table.Where(u => u.OwnerId == id && u.AccessLevel >= userRole)
                    .Include(u => u.Contacts.Where(c => u.OwnerId == id && u.AccessLevel >= userRole))
                    .Include(u => u.Orders.Where(c => u.OwnerId == id && u.AccessLevel >= userRole))
                    .Include(u => u.Quotes.Where(c => u.OwnerId == id && u.AccessLevel >= userRole))
                    .ToListAsync();
                return accounts;
            } else
            {
                List<Account> accounts = await _table.Where(u => u.AccessLevel >= userRole)
                    .Include(u => u.Contacts.Where(c => c.AccessLevel >= userRole))
                    .Include(u => u.Orders.Where(c => c.AccessLevel >= userRole))
                    .Include(u => u.Quotes.Where(c => c.AccessLevel >= userRole))
                    .ToListAsync();
                return accounts;
            }
        }
    }
}
