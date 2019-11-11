using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingUI1Proj.Data;
using BankingUI1Proj.Models;

namespace BankingUI1Proj.BusinessLayer
{
    public class TransactionBL
    {
        private readonly ApplicationDbContext _db;
        public TransactionBL(ApplicationDbContext context)
        {
            _db = context;
        }
        public List<Transaction> DisplayTransactions(int accNo)
        {
            var transactions = _db.Transactions.Where(c => c.AccountNum == accNo).ToList();
            return transactions;
        }
    }
}
