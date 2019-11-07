using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace BankingUI1Proj.Models
{
    public class ApplicationUser : IdentityUser
    {
        // referencing IdentityUser table with Customer table
        public virtual IEnumerable<Customer> Customer { get; set; }
    }
}
