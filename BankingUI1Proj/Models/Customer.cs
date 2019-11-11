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

        [Required(ErrorMessage = "Required")]
        [StringLength(2)]
        public string State { get; set; }

        [RegularExpression("^[0-9]{5}$", ErrorMessage = "Must be Valid Zipcode")]
        [Required(ErrorMessage = "Required | Must be in a Valid Format")]
        public string Zipcode { get; set; }

        
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Must be Valid Numbers")]
        [Display(Name = "Social Security #")]
        [Required(ErrorMessage = "Required | Must be in a Valid Format")]
        public string SocialSecurity { get; set; }
        //@Scripts.Render("~/bundles/jqueryval")
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Loan> Loans { get; set; }

    }
}
