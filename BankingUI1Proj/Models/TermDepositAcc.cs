using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankingUI1Proj.Models
{
    public class TermDepositAcc : Account
    {
        [Display(Name = "Maturity Date")]
        [Required (ErrorMessage = "Unable to Assign Maturity Date")]
        [DataType(DataType.Date)]
        public DateTime MaturityDate { get; set; }

        [Required]
        [Display(Name = "Interest Rate")]
        public double InterestRate { get; set; }

        [Display(Name = "Accrued Interest")]
        public double AccruedInterest { get; set; }
        
        public IEnumerable<TdcTransact> TdcTransaction { get; set; }
    }
}
