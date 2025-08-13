using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Concrete;
using Boolean.CSharp.Main.Concrete.Accounts;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void CalculateBalanceFromTransactionHistoryTest()
        {
            decimal deposit1 = 1000;
            decimal deposit2 = 500;
            decimal withdraw1 = -1000;

            CurrentAccount currentAccount = new CurrentAccount(Branch.Oslo);
            currentAccount.AddTransaction(deposit1);
            currentAccount.AddTransaction(deposit2);
            currentAccount.AddTransaction(withdraw1);

            decimal expectedBalance = 500;
            decimal calculatedBalance = currentAccount.CalculateBalance();

            Assert.That(calculatedBalance, Is.EqualTo(expectedBalance));
            Assert.That(calculatedBalance, Is.EqualTo(currentAccount.Balance));
        }
        [Test]
        public void OverdraftBankAccountTest()
        {
            
            // Zero balance account
            CurrentAccount currentAccount1 = new CurrentAccount(Branch.Bergen);
            // 500 balance account
            CurrentAccount currentAccount2 = new CurrentAccount(Branch.Oslo);
            currentAccount2.AddTransaction(500);
            // Zero balance account reject overdraft
            CurrentAccount currentAccount3 = new CurrentAccount(Branch.Trondheim);
            // Not overdraft beyond limit
            CurrentAccount currentAccount4 = new CurrentAccount(Branch.Oslo);

            Overdraft overdraft1 = currentAccount1.RequestOverdraft(500);
            bool approved1 = currentAccount1.ProcessOverdraftRequest(true);
            decimal balance1 = currentAccount1.AddTransaction(-200);

            Overdraft overdraft2 = currentAccount2.RequestOverdraft(500);
            bool approved2 = currentAccount2.ProcessOverdraftRequest(true);
            decimal balance2 = currentAccount2.AddTransaction(-600);

            Overdraft overdraft3 = currentAccount3.RequestOverdraft(500);
            bool approved3 = currentAccount3.ProcessOverdraftRequest(false);
            decimal rejected = currentAccount3.AddTransaction(-100);

            Overdraft overdraft4 = currentAccount4.RequestOverdraft(500);
            bool approved4 = currentAccount4.ProcessOverdraftRequest(true);
            decimal rejected2 = currentAccount4.AddTransaction(-600);

            Assert.IsTrue(approved1);
            Assert.IsTrue(approved2);
            Assert.IsFalse(approved3);
            Assert.IsTrue(approved4);

            Assert.That(balance1, Is.EqualTo(-200));
            Assert.That(balance2, Is.EqualTo(-100));
            Assert.That(rejected, Is.EqualTo(-1));
            Assert.That(rejected2, Is.EqualTo(-1));


        }
    }
}
