using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankingUI1Proj.Models
{
    public abstract class Account
    {
        [Key]
        [Display(Name = "Account Number")]
        public int AccountNum { get; set; }

        [Display(Name = "Current Balance")]
        [DataType(DataType.Currency)]
        public double Balance { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [Required]
        public int Customer_Id { get; set; }
        public Customer Customer { get; set; }
    }
}
