using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankingUI1Proj.Models
{
    public class TDCAdditionInfo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Maturity Date")]
        [DataType(DataType.Date)]
        public DateTime MaturityDate { get; set; }

        [Display(Name = "Accrued Interest")]
        public double AccruedInterest { get; set; }

        [Required]
        public int AccountNum { get; set; }
        public Account Account { get; set; }
    }
}
