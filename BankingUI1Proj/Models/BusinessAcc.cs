using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankingUI1Proj.Models
{
    public class BusinessAcc : Account
    {
        [Display(Name = "Overdraft Interest Rate")]
        [Required]
        public double OverdraftInterest { get; set; }
        public ICollection<ChkTransact> Transactions { get; set; }
    }
}
