using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxMe.Models
{
    public class FederalTaxTableEntry
    {
        private readonly decimal m_limit;
        private readonly decimal m_rate;

        internal decimal Limit { get { return m_limit; } }
        internal decimal Rate { get { return m_rate; } }

        internal FederalTaxTableEntry(decimal limit, decimal rate)
        {
            m_limit = limit;
            m_rate = rate;
        }
    }
}