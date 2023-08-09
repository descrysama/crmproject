using BluePillCRM.Datas;
using BluePillCRM.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace BluePillCRM.Business.Repository
{
    public class AddressRepository : GenericRepository<Address>
    {
        public AddressRepository(BluePillCRMDbContext bluePillCRMDbContext) : base(bluePillCRMDbContext)
        {

        }

        public async Task<Address> GetSingle(int id)
        {
            Address address = await _table
                    .AsNoTracking()
                    .Include(u => u.Country)
                    .FirstOrDefaultAsync(u => u.Id == id)
                    .ConfigureAwait(false);

            if (address == null)
            {
                throw new Exception("Element non trouvé.");
            }

            return address;
        }

        public bool RemoveTrack(Address address)
        {
            try
            {
                _table.Entry(address).State = EntityState.Detached;
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
    }
}
