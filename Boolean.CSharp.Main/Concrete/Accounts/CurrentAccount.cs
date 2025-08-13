using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Concrete.Accounts
{
    public class CurrentAccount : BankAccount
    {
        private Overdraft _overdraft;
        public CurrentAccount(Branch branch) : base(branch)
        {
        }
        public override decimal AddTransaction(decimal amount)
        {
            if (_balance + amount < 0)
            {
                if (_overdraft == null) 
                {
                    return -1;
                 }
                if (_overdraft.Status != OverdraftStatus.Approved)
                {
                    return -1;
                }
                if (_balance + amount < _overdraft.Amount * -1)
                {
                    return -1;
                }
            }
            Transaction transaction = new Transaction(amount, _balance);
            _transactions.Add(transaction);
            _balance += amount;
            return  _balance;
        }

        public Overdraft RequestOverdraft(decimal amount)
        {
            _overdraft = new Overdraft(amount);
            return _overdraft;
        }

        public bool ProcessOverdraftRequest(bool approve)
        {
            if (_overdraft == null)
            {
                return false;
            }
            if (!approve)
            {
                _overdraft.Status = OverdraftStatus.Rejected;
                return false;
            }
            _overdraft.Status = OverdraftStatus.Approved;
            return true;

        }

        public string GenerateBankStatement()
        {
            StringBuilder bankStatementBuilder = new StringBuilder();
            string header = $"{"date", -19} | {"credit", -10} | {"debit", -10} | {"balance", -10} ";
            bankStatementBuilder.AppendLine(header);
            List<Transaction> transactionsDescending = _transactions.OrderByDescending(t => t.Date).ToList();
            foreach (Transaction transaction in transactionsDescending) 
            { 
                DateTime date = transaction.Date;
                string credit = transaction.Type == TransactionType.Credit ? transaction.Amount.ToString() : "";
                string debit = transaction.Type == TransactionType.Debit ? transaction.Amount.ToString() : "";
                string balance = transaction.ResultingBalance.ToString();
;               string row = $"{date, -10} | {credit, -10} | {debit, -10} | {balance, -10}";
                bankStatementBuilder.AppendLine(row);
            }
            return bankStatementBuilder.ToString();
        }
    }
}
