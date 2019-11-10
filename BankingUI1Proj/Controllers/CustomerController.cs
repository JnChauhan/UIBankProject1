using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankingUI1Proj.Data;
using BankingUI1Proj.BusinessLayer;

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
                customerExist = _custBl.ExistCustomer(userEmail);   
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
            bool customerExist = false;
            string userId;
            string userEmail = User.Identity.Name;
            string returnUrl = Url.Content("~/Customer/Index");
            if (userEmail != null)
            {
                //var customer = new CustomerBL();
                customerExist = _custBl.ExistCustomer(userEmail);
                if (!customerExist)
                {
                    ApplicationUserBL appUser = new ApplicationUserBL();
                    userId = appUser.GetUserId(userEmail);
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                _custBl.AddNewCustomer(collection["Firstname"], collection["Lastname"], collection["Address"], collection["City"], collection["State"], 
                    Convert.ToInt32(collection["Zipcode"]), Convert.ToInt32(collection["SocialSecurity"]), collection["ApplicationUserId"]);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}