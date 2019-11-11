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
    public class CustomerController : Controller
    {
        private readonly CustomerBL _custBl;
        public CustomerController()
        {
            _custBl = new CustomerBL(new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().Options));
        }

        // GET: Customer
        public ActionResult Index()
        {
            bool customerExist = false;
            string userEmail = User.Identity.Name;
            if (userEmail != null)
            {
                ApplicationUserBL appUser = new ApplicationUserBL();
                string userId = appUser.GetUserId(userEmail);
                customerExist = _custBl.ExistCustomer(userId);
                if(customerExist)
                {
                    ViewBag.Fullname = _custBl.GetCustFullName(userId);
                }
            }
            ViewBag.ExistCust = customerExist;
            return View();
        }

        /* GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        */
        // GET: Customer/Create
        public ActionResult Create()
        {
            bool customerExist;
            string userId;
            string userEmail = User.Identity.Name;
            string returnUrl = Url.Content("~/Customer/Index");
            if (userEmail != null)
            {
                //var customer = new CustomerBL();
                ApplicationUserBL appUser = new ApplicationUserBL();
                userId = appUser.GetUserId(userEmail);

                customerExist = _custBl.ExistCustomer(userId);
                if (!customerExist)
                {
                    ViewBag.AppUserId = userId;
                    return View();
                }
                else
                {
                    return LocalRedirect(returnUrl);
                }
            }
            else
            {
                return LocalRedirect(returnUrl);
            }

        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer cust)
        {
            try
            {
                //add a new customer
                _custBl.AddNewCustomer(cust.Firstname, cust.Lastname, cust.Address, cust.City, cust.State,
                    cust.Zipcode, cust.SocialSecurity, cust.ApplicationUserId);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit()
        {
            bool customerExist;
            string userId;
            string userEmail = User.Identity.Name;
            string returnUrl = Url.Content("~/Customer/Index");
            if (userEmail != null)
            {
                //var customer = new CustomerBL();
                ApplicationUserBL appUser = new ApplicationUserBL();
                userId = appUser.GetUserId(userEmail);

                customerExist = _custBl.ExistCustomer(userId);
                if (customerExist)
                {
                    var customer = _custBl.GetCustomer(_custBl.GetCustId(userId));
                    return View(customer);
                }
            }
            return LocalRedirect(returnUrl);           
            //return View(customer);*/
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer cust)
        {
            try
            {
                // Edit record of existing customer
                _custBl.EditCustomer(id, cust.Firstname, cust.Lastname, cust.Address, cust.City, cust.State,
                    cust.Zipcode, cust.SocialSecurity, cust.ApplicationUserId);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

    }
}