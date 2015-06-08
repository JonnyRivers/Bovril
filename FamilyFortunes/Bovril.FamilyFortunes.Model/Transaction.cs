using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bovril.FamilyFortunes.Model
{
    public class Transaction
    {
        private readonly DateTime m_transferredAt;
        private readonly Account m_sourceAcount;
        private readonly Account m_destinationAccount;
        private readonly Amount m_amount;
        private readonly String m_description;

        public DateTime TransferredAt { get { return m_transferredAt; } }
        public Account SourceAccount { get { return m_sourceAcount; } }
        public Account DestinationAccount { get { return m_destinationAccount; } }
        public Amount Amount { get { return m_amount; } }
        public String Description { get { return m_description; } }

        internal Transaction(DateTime transferredAt, Account sourceAcount, Account destinationAccount, Amount amount, String description)
        {
            if (sourceAcount == null)
                throw new ArgumentNullException("sourceAcount");

            if (destinationAccount == null)
                throw new ArgumentNullException("destinationAccount");

            if (amount == null)
                throw new ArgumentNullException("amount");

            if (description == null)
                throw new ArgumentNullException("description");

            m_transferredAt = transferredAt;
            m_sourceAcount = sourceAcount;
            m_destinationAccount = destinationAccount;
            m_amount = amount;
            m_description = description;
        }
    }
}

