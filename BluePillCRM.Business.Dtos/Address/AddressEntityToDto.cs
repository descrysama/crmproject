using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class AddressEntityToDto
    {
        public static readAddress ReadAddressMapper(Address entityAddress)
        {
            readAddress address = new readAddress()
            {
                Id = entityAddress.Id,
                street = entityAddress.Street,
                postalCode = entityAddress.PostalCode,
                city = entityAddress.City,
                country = new ReadCountry
                {
                    Id = entityAddress.Country.Id,
                    Name = entityAddress.Country.Name
                },
                accessLevel = entityAddress.AccessLevel,
                createdBy = entityAddress.CreatedBy,
                createdAt = entityAddress.CreatedAt,
            };

            return address;
        }
    }
}
