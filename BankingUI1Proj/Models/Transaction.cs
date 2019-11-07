using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankingUI1Proj.Models
{
    public abstract class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string TransactionType { get; set; }
        
        [Required]
        public double Amount { get; set; }
        
        [Required]
        public double NewBalance { get; set; }

        [Required]
        public int AccountId { get; set; }
    }
}
