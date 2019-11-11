using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingUI1Proj.Data;
using BankingUI1Proj.Models;

namespace BankingUI1Proj.BusinessLayer
{
    public class AccountBL
    {
        private readonly ApplicationDbContext _db;

        public AccountBL(ApplicationDbContext context)
        {
            _db = context;
        }

        public List<Account> ListAccounts(int custId)
        {
            var accountList = _db.Accounts.Where(c => c.Customer_Id == custId && c.IsActive == true).ToList();
            return accountList;
        }
        public void CreateAccount(string nameAcc, string typeAcc, int custId, double balance)
        {
            double intRate = 0;
            if(typeAcc == "Business")
            {
                intRate = 0.025;
            }
            else if(typeAcc == "Checking")
            {
                intRate = 0.015;
            }
            else if (typeAcc == "TDC")
            {
                intRate = 0.0125;
            }
            Account acc = new Account()
            {
                AccName = nameAcc,
                Balance = balance,
                IsActive = true,
                DateCreated = DateTime.Now.Date,
                AccountType = typeAcc,
                InterestRate = intRate,
                Customer_Id = custId
            };
            _db.Accounts.Add(acc);
            _db.SaveChanges();
        }

        public Account GetAccount(int id)
        {
            var account = _db.Accounts.Where(c => c.AccountNum == id && c.IsActive == true).Single();
            return account;
        }

        public bool CloseAccount(Account accToClose)
        {
            bool accClosed;
            try
            {
                if (accToClose.Balance == 0)
                {
                    accToClose.IsActive = false;
                    _db.SaveChanges();
                    accClosed = true;
                }
                else
                {
                    accClosed = false;
                }
            }
            catch(Exception)
            {
                accClosed = false;
            }
            return accClosed;
        }

        public int GetAccountId(string name)
        {
            var account = _db.Accounts.Where(c => c.AccName == name).Single();
            return account.AccountNum;
        }

        public bool ExistingAccounts(int custId)
        {
            bool exist = false;
            try
            {
                int existCount = _db.Accounts.Where(c => c.Customer_Id == custId).Count();
                if (existCount >= 1)
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

        public bool AddDeposit(double amount, int id) 
        {
            bool success = false;
            try
            {
                var account = GetAccount(id);
                if (account.AccountType != "TDC")
                {
                    account.Balance += amount;
                    _db.SaveChanges();
                    success = true;
                    UpdateTransaction(account.AccountNum, amount, account.Balance, "Deposit", account.AccName);
                }
                else
                    success = false;
            }
            catch (Exception)
            {

            }
            return success;
        }

        public bool Withdraw(double amount, int id)
        {
            bool success = false;
            try
            {
                var account = GetAccount(id);
                if(account.AccountType == "Business")
                {
                    double oldBal = account.Balance;
                    account.Balance -= amount;
                    if(account.Balance<0)
                    {
                        double interestCharge = (-(account.Balance)*account.InterestRate);
                        account.Balance -= interestCharge;
                    }
                    _db.SaveChanges();
                    success = true;
                }
                else if(account.AccountType == "Checking")
                {
                    if (amount > account.Balance)
                        success = false;
                    else
                    {
                        account.Balance -= amount;
                        _db.SaveChanges();
                        success = true;
                    }
                }
                else if(account.AccountType == "TDC")
                {
                    success = false;
                }
            }
            catch (Exception)
            {

            }
            return success;
        }

        public void OpenTdcInfo(string accName)
        {
            TDCAdditionInfo tdcInfo = new TDCAdditionInfo()
            {
                MaturityDate = DateTime.Now.Date.AddMonths(12),
                AccruedInterest = 0,
                AccountNum = GetAccountId(accName)
            };
            _db.TDCAdditionInfos.Add(tdcInfo);
            _db.SaveChangesAsync();
        }

        public TDCAdditionInfo ViewTdcAdditional(int accId)
        {
            var tdcInfo = _db.TDCAdditionInfos.Where(c => c.AccountNum == accId).Single();
            return tdcInfo;
        }

        public void UpdateTransaction(int accId, double amount, double newBal, string type, string comment)
        {
            Transaction newTrans = new Transaction()
            {
                TransactionDate = DateTime.Now.Date,
                TransactionType = type,
                Amount = amount,
                NewBalance = newBal,
                Comments = comment,
                AccountNum = accId
            };
            _db.Transactions.Add(newTrans);
            _db.SaveChanges();
        }
    }
}
