using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

namespace BankApp.Web.Mapping
{
    public interface IAccountMapper
    {
        Account Map(AccountCreateModel accountCreateModel);
    }
}
