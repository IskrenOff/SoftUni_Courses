using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Loan : ILoan
    {
        private int interestRate;
        private double amount;

        protected Loan(int interestRate, double amount)
        {
            
        }

        public int InterestRate => throw new NotImplementedException();

        public double Amount => throw new NotImplementedException();
    }
}
