using Boolean.CSharp.Main;
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
        public void TestQuestion2()
        {

        }
    }
}
