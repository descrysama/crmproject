using BluePillCRM.Datas;
using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Repository
{
    public class AddressRepository : GenericRepository<Address>
    {
        public AddressRepository(BluePillCRMDbContext bluePillCRMDbContext) : base(bluePillCRMDbContext)
        {

        }
    }
}
