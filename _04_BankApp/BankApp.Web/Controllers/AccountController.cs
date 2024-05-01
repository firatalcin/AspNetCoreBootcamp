using BankApp.Web.Data.Entities;
using BankApp.Web.Data.UnitOfWork;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IGenericRepository<Account> _accountRepository;
        //private readonly IGenericRepository<ApplicationUser> _applicationUserRepository;

        //public AccountController(IGenericRepository<Account> accountRepository, IGenericRepository<ApplicationUser> applicationUserRepository)
        //{
        //    _accountRepository = accountRepository;
        //    _applicationUserRepository = applicationUserRepository;
        //}

        private readonly IUow _uow;

        public AccountController(IUow uow)
        {
            _uow = uow;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _uow.GetRepository<ApplicationUser>().GetById(id);
            return View(new UserListModel
            {
                Id = userInfo.Id,
                Name = userInfo.Name,
                Surname = userInfo.Surname
            });
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
            _uow.GetRepository<Account>().Create(new Account
            {
                AccountNumber = accountCreateModel.AccountNumber,
                Balance = accountCreateModel.Balance,
                ApplicationUserId = accountCreateModel.ApplicationUserId
            });

            _uow.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetByUserId(int id)
        {
            var query = _uow.GetRepository<Account>().GetQueryable();
            var accounts = query.Where(x => x.ApplicationUserId == id).ToList();

            var user = _uow.GetRepository<ApplicationUser>().GetById(id);
            var list = new List<AccounListModel>();
            ViewBag.FullName = user.Name + " " + user.Surname;

            foreach (var account in accounts)
            {
                list.Add(new AccounListModel
                {
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance,
                    ApplicationUserId = account.ApplicationUserId,
                    Id = account.Id
                });
            }
            return View(list);
        }

        [HttpGet]
        public IActionResult SendMoney(int id)
        {
            var query = _uow.GetRepository<Account>().GetQueryable();
            var accounts = query.Where(x => x.Id != id).ToList();


            var list = new List<AccounListModel>();

            ViewBag.SenderId = id;

            foreach (var item in accounts)
            {
                list.Add(new AccounListModel
                {
                    AccountNumber = item.AccountNumber,
                    Balance = item.Balance,
                    ApplicationUserId = item.ApplicationUserId,
                    Id = item.Id
                });
            }

            return View(new SelectList(list, "Id", "AccountNumber"));
        }

        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel sendMoneyModel)
        {
            var sendAccount = _uow.GetRepository<Account>().GetById(sendMoneyModel.SenderId);

            sendAccount.Balance -= sendMoneyModel.Amount;
            _uow.GetRepository<Account>().Update(sendAccount);

            var account = _uow.GetRepository<Account>().GetById(sendMoneyModel.AccountId);
            account.Balance += sendMoneyModel.Amount;
            _uow.GetRepository<Account>().Update(account);

            _uow.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
