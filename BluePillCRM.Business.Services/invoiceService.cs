


using BluePillCRM.Business.Repository;
using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Services
{
	public class InvoiceService
	{
        private readonly InvoiceRepository _invoiceRepository;
        public InvoiceService(InvoiceRepository invoiceRepository)
		{
            _invoiceRepository = invoiceRepository;
		}

        public async Task<Invoice> FindById(int id)
        {
            try
            {
                Invoice product = await _invoiceRepository.GetById(id);
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

