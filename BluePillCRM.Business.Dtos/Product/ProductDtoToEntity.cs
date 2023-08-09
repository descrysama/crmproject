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

        public static Product UpdateProductMapper(UpdateProduct updateProduct, Product oldProduct, int UserId)
        {
            return new Product()
            {
                Id = updateProduct.Id,
                ProductName = updateProduct.ProductName != null ? updateProduct.ProductName : oldProduct.ProductName,
                SerialNumber = updateProduct.SerialNumber != null ? updateProduct.SerialNumber : oldProduct.SerialNumber,
                Price = updateProduct.Price != 0 ? updateProduct.Price : oldProduct.Price,
                Description = updateProduct.Description != null ? updateProduct.Description : oldProduct.Description,
                UpdatedAt = DateTime.Now,
                CreatedAt = oldProduct.CreatedAt,
                CreatedBy = oldProduct.CreatedBy,
                UpdatedBy = UserId,
            };
        }
    }
}
