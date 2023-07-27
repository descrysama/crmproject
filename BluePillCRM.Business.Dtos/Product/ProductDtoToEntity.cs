using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class ProductDtoToEntity
    {
        public static Product CreateProductMapper(CreateProduct createProduct, int UserId)
        {
            return new Product()
            {
                ProductName = createProduct.ProductName,
                SerialNumber = createProduct.SerialNumber,
                Price = createProduct.Price,
                Description = createProduct.Description,
                IsDisabled = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UpdatedBy = UserId,
                CreatedBy = UserId
            };
        }
    }
}
