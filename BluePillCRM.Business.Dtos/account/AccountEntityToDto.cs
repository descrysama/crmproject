using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class AccountEntityToDto
    {
        public static readAccount readAccountMapper(Account readAccount)
        {
            readAccount account = new readAccount()
            {

                CompanyName = readAccount.CompanyName,
                Siret = readAccount.Siret,
                MainEmail = readAccount.MainEmail,
                PhoneNumber = readAccount.PhoneNumber,
                TvaNumber = readAccount.TvaNumber,
                WebsiteUrl = readAccount.WebsiteUrl,
                AccountType = readAccount.AccountType,
                AccessLevel = readAccount.AccessLevel,
                CreatedBy = readAccount.CreatedBy,
                PaymentMethodId = readAccount.PaymentMethodId,
                OwnerId = readAccount.OwnerId,
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
