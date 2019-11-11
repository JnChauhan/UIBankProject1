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

        public Customer GetCustomer(int id)
        {
            var customer = _db.Customers.Where(c => c.Id == id).Single();
            return customer;
        }
        public string CustUserId(string userEmail)
        {
            ApplicationUserBL appUser = new ApplicationUserBL();
            string userId = appUser.GetUserId(userEmail);
            return userId;
        }
        public bool ExistCustomer(string userId)
        {
            bool exist = false;
            //var db = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().Options);
            try
            {
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
        
        public void AddNewCustomer(string fname, string lname, string address, string city, string state, string zipcode, string socialSec, string userId)
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

        public void EditCustomer(int custId, string fname, string lname, string address, string city, string state, string zipcode, string socialSec, string userId)
        {
            var cust = GetCustomer(custId);
            cust.Firstname = fname;
            cust.Lastname = lname;
            cust.Address = address;
            cust.City = city;
            cust.State = state;
            cust.Zipcode = zipcode;
            cust.SocialSecurity = socialSec;
            cust.ApplicationUserId = userId;
            _db.SaveChangesAsync();
        }
        public string GetCustFullName(string userId)
        {
            string fullName = "";
            try
            {
                if (ExistCustomer(userId))
                {
                    var customer = _db.Customers.Where(c => c.ApplicationUserId == userId).Single();
                    fullName = customer.Firstname + " " + customer.Lastname;
                }
            }
            catch (Exception)
            {
            }
            return fullName;
        }

        public int GetCustId(string userId)
        {
            int custId = 0;
            try
            {
                if (ExistCustomer(userId))
                {
                    var customer = _db.Customers.Where(c => c.ApplicationUserId == userId).Single();
                    custId = customer.Id;
                }
            }
            catch (Exception)
            {

            }
            return custId;
        }
    }
}
