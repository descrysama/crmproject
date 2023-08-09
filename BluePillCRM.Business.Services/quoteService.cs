using BluePillCRM.Business.Repository;


namespace BluePillCRM.Business.Services
{
	public class QuoteService
	{
		private readonly QuoteRepository _quoteRepository; 

		public QuoteService(QuoteRepository quoteRepository)
		{
			_quoteRepository = quoteRepository;

        }


	}
}

