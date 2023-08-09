using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class AddressDtoToEntity
    {
        public static Address createAddressMapper(createAddress createAddress)
        {
            Address address = new ()
            {
                Street = createAddress.Street,
                PostalCode = createAddress.PostalCode,
                City = createAddress.City,
                CountryId = createAddress.CountryId,
                AccessLevel = createAddress.AccessLevel,
                CreatedBy = createAddress.CreatedBy
            };

            return address;
        }

        public static Address updateAddressMapper(updateAddress updateAddress, Address currentAddress)
        {
            Address address = new ()
            {
                Id = updateAddress.Id,
                Street = updateAddress.Street != null ? updateAddress.Street : currentAddress.Street,
                PostalCode = updateAddress.PostalCode != null ? updateAddress.PostalCode : currentAddress.PostalCode,
                City = updateAddress.City != null ? updateAddress.City : currentAddress.City,
                CountryId = updateAddress.CountryId != null && updateAddress.CountryId != 0 ? updateAddress.CountryId : currentAddress.CountryId,
                AccessLevel = updateAddress.AccessLevel != null && updateAddress.CountryId != 0 ? updateAddress.AccessLevel : currentAddress.AccessLevel,
                ModifiedBy = updateAddress.ModifiedBy,
                UpdatedAt = DateTime.UtcNow

            };
    
            return address;
        }

        public static Address deleteAddressMapper(int addressId)
        {
            Address address = new ()
            {
                Id = addressId

            };

            return address;
        }
    }
}
