using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingUI1Proj.Models
{
    public class BizTransact : Transaction
    {
        public BusinessAcc BizAcc { get; set; }
    }
}
