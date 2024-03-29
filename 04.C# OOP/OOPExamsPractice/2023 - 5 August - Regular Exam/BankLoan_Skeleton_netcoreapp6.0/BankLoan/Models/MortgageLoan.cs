using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    internal class MortgageLoan : Loan
    {
        public MortgageLoan(int interestRate, double amount) 
            : base(3, 50000)
        {
        }
    }
}
