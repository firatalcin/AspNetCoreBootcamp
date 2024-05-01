using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

namespace BankApp.Web.Mapping
{
    public class AccountMapper : IAccountMapper
    {
        public Account Map(AccountCreateModel accountCreateModel)
        {
            return new Account
            {
                AccountNumber = accountCreateModel.AccountNumber,
                ApplicationUserId = accountCreateModel.ApplicationUserId,
                Balance = accountCreateModel.Balance
            };
        }
    }
}
