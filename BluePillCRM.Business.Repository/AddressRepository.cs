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
