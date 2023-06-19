using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class AccountDtoToEntity
    {
        public static Account createAccountMapper(createAccount createAccount)
        {
            Account account = new Account()
            {

                CompanyName = createAccount.CompanyName,
                Siret = createAccount.Siret,
                MainEmail = createAccount.MainEmail,
                PhoneNumber = createAccount.PhoneNumber,
                TvaNumber = createAccount.TvaNumber,
                WebsiteUrl = createAccount.WebsiteUrl,
                AccountType = createAccount.AccountType,
                AccessLevel = createAccount.AccessLevel,
                CreatedBy = createAccount.CreatedBy,
                PaymentMethodId = createAccount.PaymentMethodId,
                OwnerId = createAccount.OwnerId,
                Description = createAccount.Description
            };

            return account;
        }
    }
}
