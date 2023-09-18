using BluePillCRM.Business.Repository;
using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Services
{
	public class QuoteService
	{
		private readonly QuoteRepository _quoteRepository; 

		public QuoteService(QuoteRepository quoteRepository)
		{
			_quoteRepository = quoteRepository;

        }

		public async Task<Quote> CreateQuote(Quote quote)
		{
			try
			{
				Quote createdQuote = await _quoteRepository.CreateQuote(quote);
				return createdQuote;

			} catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<Quote>> FindByContact(int contactId,Boolean onlyAcceptedQuotes)
		{
			try
			{
				List<Quote> fetchedQuote = await _quoteRepository.FindByContact(contactId, onlyAcceptedQuotes);
				return fetchedQuote;
			}catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

        public async Task<List<Quote>> FindByAccount(int accountId, Boolean onlyAcceptedQuotes)
        {
            try
            {
                List<Quote> fetchedQuote = await _quoteRepository.FindByAccount(accountId, onlyAcceptedQuotes);
                return fetchedQuote;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Quote> Update(Quote quote)
		{
			try
			{
				Quote updatedQuote = await _quoteRepository.Update(quote);
				return updatedQuote;
			} catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}


	}
}

