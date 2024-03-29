using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    internal class StudentLoan : Loan
    {
        public StudentLoan(int interestRate, double amount) 
            : base(1, 10000)
        {
        }
    }
}
