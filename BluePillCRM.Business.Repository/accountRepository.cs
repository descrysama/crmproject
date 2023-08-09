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
            Account type = await _table.AsNoTracking()
                .Include(u => u.CreatedByNavigation)
                .Include(u => u.Owner)
                .Include(u => u.DeliveryAddress)
                    .ThenInclude(u => u.Country)
                .Include(u => u.BillingAddress)
                    .ThenInclude(u => u.Country)
                .FirstOrDefaultAsync(u => u.CompanyName == companyName);
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
                Account type = await _table.AsNoTracking()
                    .Include(u => u.CreatedByNavigation)
                    .Include(u => u.Owner)
                    .Include(u => u.DeliveryAddress)
                        .ThenInclude(u => u.Country)
                    .Include(u => u.BillingAddress)
                        .ThenInclude(u => u.Country)
                    .FirstOrDefaultAsync(u => u.Siret == siretNumber);
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
            var query = _table.AsNoTracking()
                .Include(u => u.CreatedByNavigation)
                .Include(u => u.Owner)
                .Include(u => u.DeliveryAddress)
                    .ThenInclude(u => u.Country)
                .Include(u => u.BillingAddress)
                    .ThenInclude(u => u.Country)
                .Where(u => u.AccessLevel >= userRole);

            if (getOwnOnly == 1)
            {
                query = query.Where(u => u.OwnerId == id);
            }

            return await query.ToListAsync();
        }

    }
}
