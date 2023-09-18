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
                


                return await this.GetQuotePopulated(createQuote.Id);

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Quote> GetQuotePopulated(int Id)
        {
            return await _table
                .Include(u => u.UpdatedByNavigation)
                .Include(u => u.Taxes)
                .Include(u => u.PaymentMethodNavigation)
                .Include(u => u.CreatedByNavigation)
                .SingleOrDefaultAsync(qp => qp.Id == Id).ConfigureAwait(false);
        }

        public async Task<List<Quote>> FindByContact(int contactId, Boolean onlyAcceptedQuotes)
        {
            try
            {

                List<Quote> fetchedQuote = await _table.Where(q => q.ContactId == contactId && q.QuoteStatus == onlyAcceptedQuotes)
                    .Include(u => u.UpdatedByNavigation)
                    .Include(u => u.Taxes)
                    .Include(u => u.PaymentMethodNavigation)
                    .Include(u => u.CreatedByNavigation)
                    .ToListAsync().ConfigureAwait(false);
                
                return fetchedQuote;

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Quote>> FindByAccount(int AccountId, Boolean onlyAcceptedQuotes)
        {
            try
            {

                List<Quote> fetchedQuote = await _table.Where(q => q.AccountId == AccountId && q.QuoteStatus == onlyAcceptedQuotes)
                    .Include(u => u.UpdatedByNavigation)
                    .Include(u => u.Taxes)
                    .Include(u => u.PaymentMethodNavigation)
                    .Include(u => u.CreatedByNavigation)
                    .ToListAsync().ConfigureAwait(false);

                return fetchedQuote;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

