using BluePillCRM.Datas;
using BluePillCRM.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace BluePillCRM.Business.Repository
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(BluePillCRMDbContext bluePillCRMDbContext) : base(bluePillCRMDbContext)
        {

        }

        public async Task<List<Product>> GetPagination(int page, int amount)
        {
            try
            {
                List<Product> products = await _table.Where(product => product.IsDisabled == false).Skip(amount * (page - 1)).Take(amount).ToListAsync().ConfigureAwait(false);
                return products;

            } catch(Exception ex)
            {
                throw new Exception("Une erreur s'est produite.");
            }
        }

        public async Task<bool> SoftDelete(int id)
        {
            try
            {
                Product product = await _table.FindAsync(id).ConfigureAwait(false);
                this.RemoveTrack(product);
                if(product != null)
                {
                    product.IsDisabled = true;
                    _table.Update(product);
                    await _bluePillCRMDbContext.SaveChangesAsync();
                    return true;

                } else
                {
                    throw new Exception("Une erreur s'est produite. Le produit n'a pas été supprimé.");
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> RecoverSoftDeleted(int id)
        {
            try
            {
                Product product = await _table.FindAsync(id).ConfigureAwait(false);
                this.RemoveTrack(product);
                if (product != null)
                {
                    product.IsDisabled = false;
                    _table.Update(product);
                    await _bluePillCRMDbContext.SaveChangesAsync();
                    return product;

                }
                else
                {
                    throw new Exception("Une erreur s'est produite. Le produit n'a pas été supprimé.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RemoveTrack(Product product)
        {
            try
            {
                _table.Entry(product).State = EntityState.Detached;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
