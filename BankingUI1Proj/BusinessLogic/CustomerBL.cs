using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankingUI1Proj.Data;
using BankingUI1Proj.Models;

namespace BankingUI1Proj.BusinessLayer
{
    public class CustomerBL
    {
        //private readonly MyDbContext _db = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().Options);
        //private DbContext _db = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().Options);
        //= new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().Options);

        private readonly ApplicationDbContext _db;
        
        public CustomerBL (ApplicationDbContext context)
        {
            _db = context;
        }


        public bool ExistCustomer(string userEmail)
        {
            bool exist = false;
            //var db = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().Options);
            try
            {
                ApplicationUserBL appUser = new ApplicationUserBL();
                string userId = appUser.GetUserId(userEmail);
                int existCount = _db.Customers.Where(c => c.ApplicationUserId == userId).Count();
                if (existCount == 1)
                    exist = true;
                else
                    exist = false;
            }
            catch (Exception)
            {
                exist = false;
            }

            return exist;
        }
        
        public void AddNewCustomer(string fname, string lname, string address, string city, string state, int zipcode, int socialSec, string userId)
        {
            Customer cust = new Customer()
            {
                Firstname = fname,
                Lastname = lname,
                Address = address,
                City = city, 
                State = state,
                Zipcode = zipcode,
                SocialSecurity = socialSec,
                ApplicationUserId = userId
            };

            _db.Customers.Add(cust);
            _db.SaveChanges();
        }

    }
}
