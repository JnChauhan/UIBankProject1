using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingUI1Proj.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingUI1Proj.BusinessLayer
{
    public class ApplicationUserBL
    {
        //private readonly MyDbContext _db;
        /*public ApplicationUserBL(MyDbContext context)
        {
            _db = context;
        }*/
        //private readonly MyDbContext _db = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().Options);
        private readonly ApplicationDbContext _db = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().Options);
        public string GetUserId(string emailId)
        {
            //var db = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().Options);

            try
            {
                var user = _db.ApplicationUsers.Where(c => c.Email == emailId).Single();
                return user.Id;
            }
            catch (Exception)
            {
                return "Not Found!";
            }



        }
    }
}
