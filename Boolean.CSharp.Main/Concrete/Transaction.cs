using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concrete
{
    public class Transaction
    {
        private TransactionType _type;
        private decimal _amount; // Assume absolute value
        private decimal _resultingBalance;

        public Transaction(decimal amount, decimal currentBalance)
        {
            _amount = Math.Abs(amount);
            _type = amount > 0 ? TransactionType.Credit : TransactionType.Debit;
            _resultingBalance = currentBalance + amount;
        }

        public TransactionType Type { get { return _type; } }
        public decimal Amount { get { return _amount; } }
        public decimal ResultingBalance
        {
            get { return _resultingBalance; }
        }
    }
}
