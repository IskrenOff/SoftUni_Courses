using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Loan
    {
        private int interestRate;
        private double amount;

        protected Loan(int interestRate, double amount)
        {
                
        }
    }
}
