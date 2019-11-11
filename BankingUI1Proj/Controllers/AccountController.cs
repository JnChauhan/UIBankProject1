using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankingUI1Proj.Data;
using BankingUI1Proj.BusinessLayer;
using BankingUI1Proj.Models;

namespace BankingUI1Proj.Controllers
{
    public class AccountController : Controller
    {

        private readonly AccountBL _accountBl;
        private readonly CustomerBL _custBl;
        public AccountController()
        {
            _accountBl = new AccountBL(new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().Options));
            _custBl = new CustomerBL(new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().Options));
        }
        // GET: Account
        public ActionResult Index()
        {
            string userEmail = User.Identity.Name;
            string returnUrl;
            List<Account> accounts;
            if (userEmail != null)
            {
                int custId = FindCustId(userEmail);
                
                if (custId > 0)
                {
                    ViewBag.NoOpenAccount = false;
                    if (_accountBl.ExistingAccounts(custId))
                    {
                        accounts = _accountBl.ListAccounts(custId);
                        return View(accounts);
                    }
                    else
                    {
                        ViewBag.Message = "Cannot find any open account";
                        ViewBag.NoOpenAccount = true;
                        return View();
                    }
                }
                else
                {
                    returnUrl = Url.Content("~/Customer/Index");
                    return LocalRedirect(returnUrl);
                }
            }
            else
            {
                returnUrl = Url.Content("~/Home/Index");
                return LocalRedirect(returnUrl);
            }
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            string userEmail = User.Identity.Name;
            string returnUrl;
            if (userEmail != null)
            {
                int custId = FindCustId(userEmail);
                if(custId > 0)
                {
                    return View();
                }
                else
                {
                    returnUrl = Url.Content("~/Customer/Index");
                    return LocalRedirect(returnUrl);
                }
            }
            else
            {
                returnUrl = Url.Content("~/Home/Index");
                return LocalRedirect(returnUrl);
            }
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account account)
        {
            try
            {
                int custId = FindCustId(User.Identity.Name);
                _accountBl.CreateAccount(account.AccName.ToUpper(), account.AccountType, custId,0);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateTdc()
        {
            string userEmail = User.Identity.Name;
            string returnUrl;
            if (userEmail != null)
            {
                int custId = FindCustId(userEmail);
                if (custId > 0)
                {
                    return View();
                }
                else
                {
                    returnUrl = Url.Content("~/Customer/Index");
                    return LocalRedirect(returnUrl);
                }
            }
            else
            {
                returnUrl = Url.Content("~/Home/Index");
                return LocalRedirect(returnUrl);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTdc(IFormCollection collection)
        {
            try
            {
                int custId = FindCustId(User.Identity.Name);
                _accountBl.CreateAccount(collection["AccName".ToUpper()], collection["AccountType"], custId, Convert.ToDouble(collection["Balance"]));
                _accountBl.OpenTdcInfo(collection["AccName".ToUpper()]);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Deposit(int id)
        {
            string userEmail = User.Identity.Name;
            string returnUrl;
            if (userEmail != null)
            {
                var account = _accountBl.GetAccount(id);
                return View(account);
            }
            else
            {
                returnUrl = Url.Content("~/Home/Index");
                return LocalRedirect(returnUrl);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposit(Account acc)
        {
            string returnUrl = Url.Content("~/Customer/Index");
            try
            {
                bool successful = _accountBl.AddDeposit(acc.Balance,acc.AccountNum);
                
                if(successful)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    returnUrl = Url.Content("~/Account/Error");
                    return LocalRedirect(returnUrl);
                }
            }
            catch
            {
                return LocalRedirect(returnUrl);
            }
        }

        public ActionResult Withdraw(int id)
        {
            string userEmail = User.Identity.Name;
            string returnUrl;
            if (userEmail != null)
            {
                var account = _accountBl.GetAccount(id);
                return View(account);
            }
            else
            {
                returnUrl = Url.Content("~/Home/Index");
                return LocalRedirect(returnUrl);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Withdraw(Account acc)
        {
            string returnUrl = Url.Content("~/Customer/Index");
            try
            {
                bool successful = _accountBl.Withdraw(acc.Balance, acc.AccountNum);
                if (successful)
                    return LocalRedirect(returnUrl);
                else
                {
                    returnUrl = Url.Content("~/Account/Error");
                    return LocalRedirect(returnUrl);
                }
            }
            catch
            {
                return LocalRedirect(returnUrl);
            }
        }

        public ActionResult Error()
        {
            return View();
        }
        // GET: Account/Close/5
        
        public ActionResult Close(int id)
        {
            string userEmail = User.Identity.Name;
            string returnUrl;
            if (userEmail != null)
            {
                var account = _accountBl.GetAccount(id);
                if (account.Balance == 0)
                {
                    ViewBag.AccountClosed = _accountBl.CloseAccount(account);
                }
                else
                {
                    ViewBag.AccountClosed = false;
                    if (account.AccountType == "TDC")
                    {
                        var tdcInfo = _accountBl.ViewTdcAdditional(id);
                        ViewBag.MaturityDate = (tdcInfo.MaturityDate).Date;
                    }

                }
                return View(account);
            }
            else
            {
                returnUrl = Url.Content("~/Home/Index");
                return LocalRedirect(returnUrl);
            }
        }
        /*
        // POST: Account/Close/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Close(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */

        public IActionResult Transfer(int id)
        {
            
            string userEmail = User.Identity.Name;
            int custId = FindCustId(userEmail);
            var myAccounts = _accountBl.ListAccounts(custId);
            ViewBag.CurrentAccountId = id;
            return View(myAccounts);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Transfer(IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult ViewTransaction(int Id)
        {
            string userEmail = User.Identity.Name;
            string returnUrl;
            List<Transaction> transaction;
            if (userEmail != null && Id != 0)
            {
                TransactionBL _transactBl = new TransactionBL(new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().Options));
                transaction = _transactBl.DisplayTransactions(Id);
                return View(transaction);

            }
            else
            {
                returnUrl = Url.Content("~/Account/Index");
                return LocalRedirect(returnUrl);
            }
        }

        private int FindCustId(string userEmail)
        {
            ApplicationUserBL appUser = new ApplicationUserBL();
            string userId = appUser.GetUserId(userEmail);
            int custId = _custBl.GetCustId(userId);
            ViewBag.Fullname = _custBl.GetCustFullName(userId);
            return custId;
        }
    }
}