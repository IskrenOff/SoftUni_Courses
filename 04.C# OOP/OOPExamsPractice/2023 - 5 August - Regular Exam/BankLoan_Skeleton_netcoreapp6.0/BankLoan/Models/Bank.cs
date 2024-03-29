using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private int capacity;
        private List<ILoan> loans;
        private List<IClient> clients;

        public Bank(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name 
        {
            get => name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public int Capacity 
        {
            get => capacity;
            private set 
            {
                capacity = value;
            }
        }

        public IReadOnlyCollection<ILoan> Loans => this.loans;

        public IReadOnlyCollection<IClient> Clients => this.clients;

        public void AddClient(IClient Client)
        {
            if (this.Clients.Count < this.Capacity) 
            {
                this.clients.Add(Client);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void AddLoan(ILoan loan)
        {
            this.loans.Add(loan);
        }

        public string GetStatistics()
        {
            throw new NotImplementedException();
        }

        public void RemoveClient(IClient Client)
        {
            this.clients.Remove(Client);
        }

        public double SumRates()
        {
            throw new NotImplementedException();
        }
    }
}
