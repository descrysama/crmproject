using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class AccountEntityToDto
    {
        public static readAccount readAccountMapper(Account readAccount)
        {
            readAccount account = new readAccount()
            {
                Id = readAccount.Id,
                CompanyName = readAccount.CompanyName,
                Siret = readAccount.Siret,
                MainEmail = readAccount.MainEmail,
                PhoneNumber = readAccount.PhoneNumber,
                TvaNumber = readAccount.TvaNumber,
                WebsiteUrl = readAccount.WebsiteUrl,
                AccountType = readAccount.AccountType,
                AccessLevel = readAccount.AccessLevel,
                DeliveryAddress = readAccount.DeliveryAddress != null ? new readAddress
                {
                    Id = readAccount.DeliveryAddress.Id,
                    street = readAccount.DeliveryAddress.Street,
                    postalCode = readAccount.DeliveryAddress.PostalCode,
                    city = readAccount.DeliveryAddress.City,
                    country = new ReadCountry
                    {
                        Id = readAccount.DeliveryAddress.Country.Id,
                        Name = readAccount.DeliveryAddress.Country.Name
                    }
                } : null,
                BillingAddress = readAccount.BillingAddress != null ? new readAddress
                {
                    Id = readAccount.DeliveryAddress.Id,
                    street = readAccount.DeliveryAddress.Street,
                    postalCode = readAccount.DeliveryAddress.PostalCode,
                    city = readAccount.DeliveryAddress.City,
                    country = new ReadCountry
                    {
                        Id = readAccount.DeliveryAddress.Country.Id,
                        Name = readAccount.DeliveryAddress.Country.Name
                    }
                } : null,
                CreatedBy = new readUser
                {
                    Id = readAccount.CreatedByNavigation.Id,
                    Username = readAccount.CreatedByNavigation.Username,
                    Email = readAccount.CreatedByNavigation.Email,
                    Name = readAccount.CreatedByNavigation.Name,
                    LastName = readAccount.CreatedByNavigation.LastName,
                    IsDisabled = readAccount.CreatedByNavigation.IsDisabled,
                    Title = readAccount.CreatedByNavigation.Title,
                    RoleId = readAccount.CreatedByNavigation.RoleId

                },
                PaymentMethodId = readAccount.PaymentMethodId,
                OwnedBy = new readUser
                {
                    Id = readAccount.Owner.Id,
                    Username = readAccount.Owner.Username,
                    Email = readAccount.Owner.Email,
                    Name = readAccount.Owner.Name,
                    LastName = readAccount.Owner.LastName,
                    IsDisabled = readAccount.Owner.IsDisabled,
                    Title = readAccount.Owner.Title,
                    RoleId = readAccount.Owner.RoleId
                },
                Description = readAccount.Description,
            };

            return account;
        }


        public static List<readAccount> ReadAccountListMapper(List<Account> accounts)
        {
            List<readAccount> userList = new ();

            foreach (var account in accounts)
            {
                readAccount readAccount = readAccountMapper(account);
                userList.Add(readAccount);
            }

            return userList;
        }
    }
}
