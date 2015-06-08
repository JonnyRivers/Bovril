using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bovril.FamilyFortunes.Model
{
    internal class Ledger
    {
        private readonly SetOfAccounts m_setOfAccounts;
        private readonly List<Transaction> m_transactions;

        private SetOfAccounts SetOfAccounts { get { return m_setOfAccounts; } }

        internal Ledger(SetOfAccounts setOfAccounts)
        {
            m_setOfAccounts = setOfAccounts;
            m_transactions = new List<Transaction>();
        }

        internal Transaction CreateTransaction(DateTime transferredAt, Account sourceAcount, Account destinationAccount, Amount amount, String description)
        {
            var newTransaction = new Transaction(transferredAt, sourceAcount, destinationAccount, amount, description);
            m_transactions.Add(newTransaction);

            return newTransaction;
        }

        internal Amount GetAccountBalance(Account account)
        {
            Amount balance = account.OpeningBalance;

            foreach (Transaction transaction in m_transactions.Where(t => t.SourceAccount == account))
            {
                balance -= transaction.Amount;
            }

            foreach (Transaction transaction in m_transactions.Where(t => t.DestinationAccount == account))
            {
                balance += transaction.Amount;
            }

            return balance;
        }
    }
}
