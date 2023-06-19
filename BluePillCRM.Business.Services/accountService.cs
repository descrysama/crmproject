using BluePillCRM.Business.Repository;
using BluePillCRM.Datas.Entities;
using BluePillCRM.Business.Dtos;
using BluePillCRM.Business.Services.Utilities;

namespace BluePillCRM.Business.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;

        public AccountService(AccountRepository repositoryAccount)
        {
            _accountRepository = repositoryAccount;
        }

        public async Task<Account> FindOneByCompanyName(string companyName)
        {
            Account account = await _accountRepository.FindOneByCompanyName(companyName).ConfigureAwait(false);
            return account;
        }

        public async Task<Account> CreateAccount(createAccount createdAccount)
        {
            Account checkIfCompnayNameIsUsed = await this.FindOneByCompanyName(createdAccount.CompanyName);

            if (checkIfCompnayNameIsUsed == null)
            {
                Account newAccount = await _accountRepository.Insert(AccountDtoToEntity.createAccountMapper(createdAccount)).ConfigureAwait(false);
                return newAccount;
            }
            else
            {
                throw new Exception("Un compte avec la même nom ou le même siret existe déjà.");
            }
        }
    }
}
