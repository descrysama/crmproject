using BluePillCRM.Business.Dtos;
using BluePillCRM.Business.Repository;
using BluePillCRM.Datas.Entities;


namespace BluePillCRM.Business.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<List<Product>> GetProductsByPage(int page, int amount)
        {
            try
            {
                return _productRepository.GetPagination(page, amount);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Product> Create(Product product)
        {
            try
            {
                return _productRepository.Insert(product);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> SoftDelete(int id)
        {
            try
            {
                return _productRepository.SoftDelete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Product> RecoverSoftDelete(int id)
        {
            try
            {
                return _productRepository.RecoverSoftDeleted(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
