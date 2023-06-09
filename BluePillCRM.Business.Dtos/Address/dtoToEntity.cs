using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class dtoToEntity
    {
        public static Address createAddressMapper(createAddress createAddress)
        {
            Address address = new Address()
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

        public static Address updateAddressMapper(updateAddress createAddress)
        {
            Address address = new Address()
            {
                Street = createAddress.Street,
                PostalCode = createAddress.PostalCode,
                City = createAddress.City,
                CountryId = createAddress.CountryId,
                AccessLevel = createAddress.AccessLevel,
                ModifiedBy = createAddress.ModifiedBy,
                UpdatedAt = DateTime.UtcNow

            };

            return address;
        }

        public static Address deleteAddressMapper(int addressId)
        {
            Address address = new Address()
            {
                Id = addressId

            };

            return address;
        }
    }
}
