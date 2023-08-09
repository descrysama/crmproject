using BluePillCRM.Datas.Entities;
using BluePillCRM.Business.Dtos;

namespace BluePillCRM.Business.Dtos
{
    public class ProductEntityToDto
    {
        public static ReadProduct ReadProductMapper(Product product)
        {
            ReadProduct readProductObject = new ReadProduct()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                SerialNumber = product.SerialNumber,
                Price = product.Price,
                Description = product.Description,
                IsDisabled = product.IsDisabled,
                updatedAt = product.UpdatedAt,
                createdAt = product.CreatedAt
            };

            if (product.CreatedByNavigation.Id > 0)
            {
                readProductObject.CreatedBy = new readUser
                {
                    Id = product.CreatedByNavigation.Id,
                    Username = product.CreatedByNavigation.Username,
                    Email = product.CreatedByNavigation.Email,
                    Name = product.CreatedByNavigation.Name,
                    LastName = product.CreatedByNavigation.LastName,
                    IsDisabled = product.CreatedByNavigation.IsDisabled,
                    Title = product.CreatedByNavigation.Title,
                    RoleId = product.CreatedByNavigation.RoleId

                };
            }

            if (product.UpdatedByNavigation.Id != null)
            {
                readProductObject.modifiedBy = new readUser
                {
                    Id = product.UpdatedByNavigation.Id,
                    Username = product.UpdatedByNavigation.Username,
                    Email = product.UpdatedByNavigation.Email,
                    Name = product.UpdatedByNavigation.Name,
                    LastName = product.UpdatedByNavigation.LastName,
                    IsDisabled = product.UpdatedByNavigation.IsDisabled,
                    Title = product.UpdatedByNavigation.Title,
                    RoleId = product.UpdatedByNavigation.RoleId

                };
            }

            return readProductObject;
        }
    }
}
