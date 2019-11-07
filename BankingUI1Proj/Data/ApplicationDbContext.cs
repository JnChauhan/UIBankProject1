using System;
using System.Collections.Generic;
using System.Text;
using BankingUI1Proj.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore; 

namespace BankingUI1Proj.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=UiBankingDB;integrated security=True;MultipleActiveResultSets=True;");
            }
        }*/
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BusinessAcc> BusinessAccs { get; set; }
        public DbSet<CheckingAcc> CheckingAccs { get; set; }
        public DbSet<TermDepositAcc> TermDepositAccs { get; set; }
        public DbSet<BizTransact> BizTransacts { get; set; }
        public DbSet<ChkTransact> ChkTransacts { get; set; }
        public DbSet<TdcTransact> TdcTransacts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
