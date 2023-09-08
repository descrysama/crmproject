using BluePillCRM.Datas;
using BluePillCRM.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace BluePillCRM.Business.Repository
{
	public class QuoteRepository : GenericRepository<Quote>
	{

        public QuoteRepository(BluePillCRMDbContext bluePillCRMDbContext) : base(bluePillCRMDbContext)
        {
        }

        public async Task<Quote> CreateQuote(Quote quote)
        {
            try
            {
                var createQuote = await this.Insert(quote).ConfigureAwait(false);

                return createQuote;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}

