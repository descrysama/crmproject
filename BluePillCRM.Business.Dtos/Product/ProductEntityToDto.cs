using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class ProductEntityToDto
    {
        public static ReadProduct ReadProductMapper(Product product)
        {
            return new ReadProduct()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                SerialNumber = product.SerialNumber,
                Price = product.Price,
                Description = product.Description,
                IsDisabled = product.IsDisabled,
                updatedAt = product.UpdatedAt,
                createdAt = product.CreatedAt,
                createdBy = product.CreatedBy,
                modifiedBy = product.UpdatedBy
            };
        }
    }
}
