using BluePillCRM.Datas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                countryId = entityAddress.CountryId,
                accessLevel = entityAddress.AccessLevel,
                createdBy = entityAddress.CreatedBy,
                createdAt = entityAddress.CreatedAt,
            };

            return address;
        }
    }
}
