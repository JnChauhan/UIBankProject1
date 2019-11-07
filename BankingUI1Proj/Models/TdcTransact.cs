using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankingUI1Proj.Models
{
    public class TdcTransact : Transaction
    {
        [Display(Name = "Closed Date")]
        [DataType(DataType.Date)]
        public DateTime CloseDate { get; set; }

        public TermDepositAcc TdcAcc { get; set; }
    }
}
