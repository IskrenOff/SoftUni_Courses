using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> loans;

        public LoanRepository()
        {
            loans = new List<ILoan>();
        }

        public IReadOnlyCollection<ILoan> Models => this.loans.AsReadOnly();

        public void AddModel(ILoan model)
        {
            throw new NotImplementedException();
        }

        public ILoan FirstModel(string name)
        {
            throw new NotImplementedException();
        }

        public bool RemoveModel(ILoan model)
        {
            throw new NotImplementedException();
        }
    }
}
