using BluePillCRM.Datas.Entities;
using BluePillCRM.Business.Repository;

namespace BluePillCRM.Business.Services
{
	public class QuoteProductService
	{

		private readonly QuoteProductRepository _quoteProductRepository;

        public QuoteProductService(QuoteProductRepository quoteProductRepository)
		{
			_quoteProductRepository = quoteProductRepository;
        }

		public async Task<QuotesProduct> Create(QuotesProduct quoteProduct)
		{
			try
			{
				return await _quoteProductRepository.Insert(quoteProduct).ConfigureAwait(false);

            } catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}

