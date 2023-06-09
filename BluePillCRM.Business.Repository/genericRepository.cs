using BluePillCRM.Datas;
using Microsoft.EntityFrameworkCore;


namespace BluePillCRM.Business.Repository
{
    public abstract class GenericRepository<T> where T : class
    {
        protected readonly BluePillCRMDbContext _bluePillCRMDbContext;

        private readonly DbSet<T> _table;

        protected GenericRepository(BluePillCRMDbContext bluePillCRMDbContext)
        {
            _bluePillCRMDbContext = bluePillCRMDbContext;
            _table = _bluePillCRMDbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> GetById(object id)
        {
            T element = await _table.FindAsync(id).ConfigureAwait(false);

            if (element == null)
            {
                throw new Exception("Element non trouvé.");
            }

            return element;
        }

        public async Task<T> Insert(T element)
        {
            var elementAdded = await _table.AddAsync(element).ConfigureAwait(false);
            await _bluePillCRMDbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        public async Task<T> Update(T element)
        {
            var elementUpdated = _table.Update(element);
            await _bluePillCRMDbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        public async Task<T> Delete(T element)
        {
            var elementDeleted = _table.Remove(element);
            await _bluePillCRMDbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }


    }
}