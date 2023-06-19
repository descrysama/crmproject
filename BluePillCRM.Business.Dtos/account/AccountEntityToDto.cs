using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class AccountEntityToDto
    {
        public static Account readAccountMapper(Account readAccount)
        {
            Account account = new Account()
            {

                CompanyName = readAccount.CompanyName,
                Siret = readAccount.Siret,
                MainEmail = readAccount.MainEmail,
                PhoneNumber = readAccount.PhoneNumber,
                TvaNumber = readAccount.TvaNumber,
                WebsiteUrl = readAccount.WebsiteUrl,
                AccountType = readAccount.AccountType,
                PaymentMethodId = readAccount.PaymentMethodId,
                OwnerId = readAccount.OwnerId,
                Description = readAccount.Description
            };

            return account;
        }
    }
}
