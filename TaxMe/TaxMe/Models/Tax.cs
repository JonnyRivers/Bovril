using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxMe.Models
{
    public class Tax
    {
        private readonly String m_name;
        private readonly TaxLine[] m_taxLines;
        private readonly decimal m_amount;

        public String Name { get { return m_name; } }
        public IEnumerable<TaxLine> Lines { get { return m_taxLines; } }
        public decimal Amount { get { return m_amount; } }

        public Tax(String name, IEnumerable<TaxLine> taxLines)
        {
            m_name = name;
            m_taxLines = taxLines.ToArray();
            m_amount = m_taxLines.Sum(tl => tl.Amount);
        }
    }
}