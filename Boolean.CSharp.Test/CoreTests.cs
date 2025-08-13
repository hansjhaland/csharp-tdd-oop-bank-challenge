using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Abstract;
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

    }
}