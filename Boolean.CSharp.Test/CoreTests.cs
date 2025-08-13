using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Concrete;
using Boolean.CSharp.Main.Concrete.Accounts;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void CreateAccountsTest()
        {

            CurrentAccount currentAccount = new CurrentAccount(Branch.Oslo);
            SavingsAccount savingsAccount = new SavingsAccount(Branch.Trondheim);

            Assert.NotNull(currentAccount);
            Assert.NotNull(savingsAccount);
            Assert.That(currentAccount.Balance, Is.EqualTo(0));
            Assert.That(savingsAccount.Balance, Is.EqualTo(0));
            Assert.That(currentAccount.Branch, Is.EqualTo(Branch.Oslo));
            Assert.That(savingsAccount.Branch, Is.EqualTo(Branch.Trondheim));
            Assert.True(currentAccount is BankAccount);
            Assert.True(savingsAccount is BankAccount);
        }

        [Test]
        public void CreateTransactionTest()
        {
            decimal currentBalance = 500;
            decimal depositAmount = 100;
            decimal withdrawAmount = -100;
            decimal resultingBalanceDeposit = currentBalance + depositAmount;
            decimal resultingBalanceWithdraw = currentBalance + withdrawAmount;

            Transaction transactionCredit = new Transaction(depositAmount, currentBalance);
            Transaction transactionDebit = new Transaction(withdrawAmount, currentBalance);

            Assert.That(transactionCredit.Amount, Is.EqualTo(depositAmount));
            Assert.That(transactionDebit.Amount, Is.EqualTo(Math.Abs(withdrawAmount)));
            Assert.That(transactionCredit.ResultingBalance, Is.EqualTo(resultingBalanceDeposit));
            Assert.That(transactionDebit.ResultingBalance, Is.EqualTo(resultingBalanceWithdraw));
            Assert.That(transactionDebit.Type, Is.EqualTo(TransactionType.Debit));
            Assert.That(transactionCredit.Type, Is.EqualTo(TransactionType.Credit));
        }

    }
}