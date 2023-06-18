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

        public async Task<createAccount> CreateAccount(createAccount createAccount)
        {
            createAccount test = new createAccount();
            return test;
        }
    }
}
