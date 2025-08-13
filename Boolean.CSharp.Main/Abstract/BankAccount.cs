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

        private protected decimal _balance = 0;
        private protected List<Transaction> _transactions = new List<Transaction>();
        private Branch _branch;

        protected BankAccount(Branch branch)
        {
            _branch = branch;
        }

        public virtual decimal AddTransaction(decimal amount)
        {
            if (_balance - amount < 0) 
            {
                return -1;
            }
            Transaction transaction = new Transaction(amount, _balance);
            _transactions.Add(transaction);
            _balance += amount; 
            return _balance;
        }

        public decimal CalculateBalance()
        {
            decimal balance = 0;
            foreach (Transaction transaction in _transactions) 
            {
                balance += transaction.Type == TransactionType.Credit ? transaction.Amount : transaction.Amount * -1;
            }
            return balance;
        }

        public string GenerateBankStatement()
        {
            StringBuilder bankStatementBuilder = new StringBuilder();
            string header = $"{"date",-19} | {"credit",-10} | {"debit",-10} | {"balance",-10} ";
            bankStatementBuilder.AppendLine(header);
            List<Transaction> transactionsDescending = _transactions.OrderByDescending(t => t.Date).ToList();
            foreach (Transaction transaction in transactionsDescending)
            {
                DateTime date = transaction.Date;
                string credit = transaction.Type == TransactionType.Credit ? transaction.Amount.ToString() : "";
                string debit = transaction.Type == TransactionType.Debit ? transaction.Amount.ToString() : "";
                string balance = transaction.ResultingBalance.ToString();
                string row = $"{date,-10} | {credit,-10} | {debit,-10} | {balance,-10}";
                bankStatementBuilder.AppendLine(row);
            }
            return bankStatementBuilder.ToString();
        }

        public Guid Id { get; set; }
        public Guid AccountNumber { get; set; } = Guid.NewGuid();
        public Branch Branch { get { return _branch; } }
        public decimal Balance { get { return _balance; } }
    }
    
}
