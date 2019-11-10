using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//using ServiceStack.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace BankingUI1Proj.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [StringLength(5)]
        [Required(ErrorMessage = "Zipcode is required & Must be in a Valid Format")]
        public int Zipcode { get; set; }

        [StringLength(9)]
        [Display(Name = "Social Security #")]
        [Required(ErrorMessage = "Please input your Social Security #")]
        public int SocialSecurity { get; set; }

        public string ApplicationUserId { get; set; }
        //[ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Loan> Loans { get; set; }

    }
}
