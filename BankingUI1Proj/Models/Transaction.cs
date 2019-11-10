using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankingUI1Proj.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Type of Transaction")]
        public string TransactionType { get; set; }
        
        [Required]
        public double Amount { get; set; }
        
        [Required]
        public double NewBalance { get; set; }

        public string Comments { get; set; }

        [Required]
        public int AccountNum { get; set; }
        public Account Account { get; set; }
    }
}
