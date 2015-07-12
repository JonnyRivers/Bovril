using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bovril.FamilyFortunes.Model
{
    /// <summary>
    /// An account within a set of accounts
    /// </summary>
    public class Account
    {
        private readonly String m_name;
        private readonly AccountType m_type;
        private readonly Amount m_openingBalance;
        private readonly SetOfAccounts m_setOfAccounts;

        public String Name { get { return m_name; } }
        public AccountType Type { get { return m_type; } }
        public Amount OpeningBalance { get { return m_openingBalance; } }
        private SetOfAccounts SetOfAccounts { get { return m_setOfAccounts; } }

        // TODO: get balance

        internal Account(String name, AccountType type, Amount openingBalance, SetOfAccounts setOfAccounts)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            if (openingBalance == null)
                throw new ArgumentNullException("openingBalance");

            if (setOfAccounts == null)
                throw new ArgumentNullException("setOfAccounts");

            m_name = name;
            m_type = type;
            m_openingBalance = openingBalance;
            m_setOfAccounts = setOfAccounts;
        }
    }
}
