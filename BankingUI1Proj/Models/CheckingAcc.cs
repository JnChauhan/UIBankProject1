using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankingUI1Proj.Models
{
    public class CheckingAcc : Account
    {
        [Display(Name = "Interest Rate")]
        public double InteresRate { get; set; }
        public ICollection<BizTransact> Transactions { get; set; }
    }
}
