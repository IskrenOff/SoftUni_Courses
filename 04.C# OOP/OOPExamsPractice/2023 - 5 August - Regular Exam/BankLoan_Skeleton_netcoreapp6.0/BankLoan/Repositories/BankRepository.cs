﻿using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> banks;

        public BankRepository()
        {
            banks = new List<IBank>();
        }

        public IReadOnlyCollection<IBank> Models => this.banks.AsReadOnly();

        public void AddModel(IBank model)
        {
            throw new NotImplementedException();
        }

        public IBank FirstModel(string name)
        {
            throw new NotImplementedException();
        }

        public bool RemoveModel(IBank model)
        {
            throw new NotImplementedException();
        }
    }
}
