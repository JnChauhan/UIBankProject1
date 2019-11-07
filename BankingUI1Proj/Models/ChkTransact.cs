using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingUI1Proj.Models
{
    public class ChkTransact : Transaction
    {
        public CheckingAcc ChkAcc { get; set; }
    }
}
