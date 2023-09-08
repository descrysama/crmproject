
using BluePillCRM.Business.Repository;
using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Services
{
	public class TaxService
	{
        private readonly TaxRepository _taxRepository;

        public TaxService(TaxRepository taxRepository)
        {
            _taxRepository = taxRepository;

        }

        public async Task<Taxis> GetById(int id)
        {
            try
            {
                Taxis tax = await _taxRepository.GetById(id);
                return tax;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

