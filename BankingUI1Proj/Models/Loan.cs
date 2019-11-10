using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingUI1Proj.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public string LoanName { get; set; }
        public double Principal { get; set; }
        public double BalanceAmount { get; set; }
        public double InterestRate { get; set; }
        public int Months { get; set; }
        public double MonthlyPayment { get; set; }
        public int Customer_id { get; set; }
        public Customer Customer { get; set; }
    }
}
