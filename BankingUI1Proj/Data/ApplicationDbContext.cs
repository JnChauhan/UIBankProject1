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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=UiBankingDB;integrated security=True;MultipleActiveResultSets=True;");
            }
        }
        
        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>().HasIndex(u => u.AccName).IsUnique();
            builder.Entity<Loan>().HasIndex(u => u.LoanName).IsUnique();
        }
        */


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<TDCAdditionInfo> TDCAdditionInfos { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
