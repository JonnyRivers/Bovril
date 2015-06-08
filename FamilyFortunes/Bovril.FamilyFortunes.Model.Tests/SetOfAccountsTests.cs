using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bovril.FamilyFortunes.Model.Tests
{
    [TestClass]
    public class SetOfAccountsTests
    {
        [TestMethod]
        public void TestCreation()
        {
            String accountName = "Test";

            var setOfAccounts = new SetOfAccounts(accountName);

            Assert.IsNotNull(setOfAccounts);
            Assert.AreEqual(setOfAccounts.Name, accountName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCreateAccountNullName()
        {
            var setOfAccounts = new SetOfAccounts("Test");

            Amount assetAccountOpeningBalance = new Amount(100, Currency.USD);

            Account assetAccount = setOfAccounts.CreateAccount(null, AccountType.Asset, assetAccountOpeningBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCreateAccountNullOpeningBalance()
        {
            var setOfAccounts = new SetOfAccounts("Test");

            Account assetAccount = setOfAccounts.CreateAccount("Test", AccountType.Asset, null);
        }

        [TestMethod]
        public void TestCreateAccount()
        {
            var setOfAccounts = new SetOfAccounts("Test");

            Currency defaultCurrency = Currency.USD;

            String assetAccountName = "Wells Fargo Checking";
            Amount assetAccountOpeningBalance = new Amount(100, defaultCurrency);

            String liabilityAccountName = "Capital One Credit Card";
            Amount liabilityAccountOpeningBalance = new Amount(-50, defaultCurrency);

            String expenseAccountName = "Rent Expense";
            Amount expenseAccountOpeningBalance = new Amount(0, defaultCurrency);

            String incomeAccountName = "Blizzard Basic Pay";
            Amount incomeAccountOpeningBalance = new Amount(0, defaultCurrency);

            Account assetAccount = setOfAccounts.CreateAccount(assetAccountName, AccountType.Asset, assetAccountOpeningBalance);
            Account liabilityAccount = setOfAccounts.CreateAccount(liabilityAccountName, AccountType.Liability, liabilityAccountOpeningBalance);
            Account expenseAccount = setOfAccounts.CreateAccount(expenseAccountName, AccountType.Expense, expenseAccountOpeningBalance);
            Account incomeAccount = setOfAccounts.CreateAccount(incomeAccountName, AccountType.Income, incomeAccountOpeningBalance);

            Assert.IsNotNull(assetAccount);
            Assert.IsNotNull(liabilityAccount);
            Assert.IsNotNull(expenseAccount);
            Assert.IsNotNull(incomeAccount);

            Assert.AreEqual(assetAccount.Name, assetAccountName);
            Assert.AreEqual(liabilityAccount.Name, liabilityAccountName);
            Assert.AreEqual(expenseAccount.Name, expenseAccountName);
            Assert.AreEqual(incomeAccount.Name, incomeAccountName);

            Assert.AreEqual(assetAccount.Type, AccountType.Asset);
            Assert.AreEqual(liabilityAccount.Type, AccountType.Liability);
            Assert.AreEqual(expenseAccount.Type, AccountType.Expense);
            Assert.AreEqual(incomeAccount.Type, AccountType.Income);

            Assert.AreEqual(assetAccount.OpeningBalance, assetAccountOpeningBalance);
            Assert.AreEqual(liabilityAccount.OpeningBalance, liabilityAccountOpeningBalance);
            Assert.AreEqual(expenseAccount.OpeningBalance, expenseAccountOpeningBalance);
            Assert.AreEqual(incomeAccount.OpeningBalance, incomeAccountOpeningBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCreateTransactionNullSourceAccount()
        {
            var setOfAccounts = new SetOfAccounts("Test");

            String assetAccountName = "Wells Fargo Checking";
            Amount assetAccountOpeningBalance = new Amount(100, Currency.USD);

            Amount amount = new Amount(100, Currency.USD);

            Account assetAccount = setOfAccounts.CreateAccount(assetAccountName, AccountType.Asset, assetAccountOpeningBalance);

            Transaction transaction = setOfAccounts.CreateTransaction(DateTime.Now, null, assetAccount, amount, "Test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCreateTransactionNullDestinationAccount()
        {
            var setOfAccounts = new SetOfAccounts("Test");

            String assetAccountName = "Wells Fargo Checking";
            Amount assetAccountOpeningBalance = new Amount(100, Currency.USD);

            Amount amount = new Amount(100, Currency.USD);

            Account assetAccount = setOfAccounts.CreateAccount(assetAccountName, AccountType.Asset, assetAccountOpeningBalance);

            Transaction transaction = setOfAccounts.CreateTransaction(DateTime.Now, assetAccount, null, amount, "Test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCreateTransactionNullAmount()
        {
            var setOfAccounts = new SetOfAccounts("Test");

            String assetAccountName = "Wells Fargo Checking";
            Amount assetAccountOpeningBalance = new Amount(100, Currency.USD);

            String liabilityAccountName = "Capital One Credit Card";
            Amount liabilityAccountOpeningBalance = new Amount(-50, Currency.USD);

            Account assetAccount = setOfAccounts.CreateAccount(assetAccountName, AccountType.Asset, assetAccountOpeningBalance);
            Account liabilityAccount = setOfAccounts.CreateAccount(liabilityAccountName, AccountType.Liability, liabilityAccountOpeningBalance);

            Transaction transaction = setOfAccounts.CreateTransaction(DateTime.Now, assetAccount, liabilityAccount, null, "Test");
        }

        [TestMethod]
        public void TestCreateTransaction()
        {
            var setOfAccounts = new SetOfAccounts("Test");

            String assetAccountName = "Wells Fargo Checking";
            Amount assetAccountOpeningBalance = new Amount(100, Currency.USD);

            String liabilityAccountName = "Capital One Credit Card";
            Amount liabilityAccountOpeningBalance = new Amount(-50, Currency.USD);

            Amount amount = new Amount(100, Currency.USD);

            Account assetAccount = setOfAccounts.CreateAccount(assetAccountName, AccountType.Asset, assetAccountOpeningBalance);
            Account liabilityAccount = setOfAccounts.CreateAccount(liabilityAccountName, AccountType.Liability, liabilityAccountOpeningBalance);

            String transactionDescription = "Test";

            Transaction transaction = setOfAccounts.CreateTransaction(DateTime.Now, assetAccount, liabilityAccount, amount, transactionDescription);

            Assert.IsNotNull(transaction);

            Assert.AreEqual(transaction.SourceAccount, assetAccount);
            Assert.AreEqual(transaction.DestinationAccount, liabilityAccount);
            Assert.AreEqual(transaction.Amount, amount);
            Assert.AreEqual(transaction.Description, transactionDescription);
        }

        [TestMethod]
        public void TestGetAccountBalance()
        {
            var setOfAccounts = new SetOfAccounts("Test");

            String assetAccountName = "Wells Fargo Checking";
            Amount assetAccountOpeningBalance = new Amount(100, Currency.USD);

            String liabilityAccountName = "Capital One Credit Card";
            Amount liabilityAccountOpeningBalance = new Amount(-50, Currency.USD);

            Amount amount = new Amount(100, Currency.USD);

            Account assetAccount = setOfAccounts.CreateAccount(assetAccountName, AccountType.Asset, assetAccountOpeningBalance);
            Account liabilityAccount = setOfAccounts.CreateAccount(liabilityAccountName, AccountType.Liability, liabilityAccountOpeningBalance);

            String transactionDescription = "Test";

            Transaction transaction = setOfAccounts.CreateTransaction(DateTime.Now, assetAccount, liabilityAccount, amount, transactionDescription);

            Amount assetAccountBalance = setOfAccounts.GetAccountBalance(assetAccount);
            Amount liabilityAccountBalance = setOfAccounts.GetAccountBalance(liabilityAccount);

            Assert.AreEqual(assetAccountBalance.Value, assetAccountOpeningBalance.Value - amount.Value);
            Assert.AreEqual(liabilityAccountBalance.Value, liabilityAccountOpeningBalance.Value + amount.Value);
        }
    }
}
