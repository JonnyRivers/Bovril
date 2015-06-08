using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bovril.FamilyFortunes.Model
{
    public class SetOfAccounts
    {
        private readonly String m_name;
        private readonly List<Account> m_accounts;
        private readonly Ledger m_ledger;

        public String Name { get { return m_name; } }

        public SetOfAccounts(String name)
        {
            m_name = name;
            m_accounts = new List<Account>();
            m_ledger = new Ledger(this);
        }

        public Account CreateAccount(String name, AccountType type, Amount openingBalance)
        {
            var newAccount = new Account(name, type, openingBalance, this);
            m_accounts.Add(newAccount);

            return newAccount;
        }

        public Transaction CreateTransaction(DateTime transferredAt, Account sourceAcount, Account destinationAccount, Amount amount, String description)
        {
            return m_ledger.CreateTransaction(transferredAt, sourceAcount, destinationAccount, amount, description);
        }

        public Amount GetAccountBalance(Account account)
        {
            return m_ledger.GetAccountBalance(account);
        }
    }
}
