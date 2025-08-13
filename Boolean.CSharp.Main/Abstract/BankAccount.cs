using Boolean.CSharp.Main.Concrete;
using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Abstract
{
    public abstract class BankAccount
    {

        private decimal _balance = 0;
        private List<Transaction> _transactions = new List<Transaction>();
        private Branch _branch;

        protected BankAccount(Branch branch)
        {
            _branch = branch;
        }

        public decimal AddTransaction(decimal amount)
        {
            throw new NotImplementedException();
        }

        public Guid Id { get; set; }
        public Guid AccountNumber { get; set; } = Guid.NewGuid();
        public Branch Branch { get { return _branch; } }
        public decimal Balance { get { return _balance; } }
    }
    
}
