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

        public async Task<Account> FindOneBySiretNumber(string siretNumber)
        {
            Account account = await _accountRepository.FindOneBySiretNumber(siretNumber).ConfigureAwait(false);
            return account;
        }

        public async Task<Account> CreateAccount(createAccount createdAccount)
        {

            Account checkIfCompnayNameIsUsed = await this.FindOneByCompanyName(createdAccount.CompanyName);
            if (checkIfCompnayNameIsUsed == null)
            {
                Account checkIfSiretNumberIsUsed = await this.FindOneBySiretNumber(createdAccount.Siret);
                if (checkIfSiretNumberIsUsed == null)
                {
                    Account newAccount = await _accountRepository.Insert(AccountDtoToEntity.createAccountMapper(createdAccount)).ConfigureAwait(false);
                    return newAccount;
                } else
                {
                    throw new Exception("Un compte avec le même SIRET existe déjà.");
                }
            }
            else
            {
                throw new Exception("Un compte avec le même nom existe déjà.");
            }
        }

        public async Task<List<readAccount>> GetAccounts(int getOwnOnly, int currentUserId, int userRole)
        {
            List<Account> accounts = await _accountRepository.GetAccountOwnedOrPublic(currentUserId, userRole, getOwnOnly).ConfigureAwait(false);
            return AccountEntityToDto.ReadAccountListMapper(accounts);
        }
    }
}
