using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxMe.Models
{
    public class TaxLine
    {
        private readonly String m_name;
        private readonly decimal m_rate;
        private readonly decimal m_amount;

        public String Name { get { return m_name; } }
        public decimal Rate { get { return m_rate; } }
        public decimal Amount { get { return m_amount; } }

        public TaxLine(String name, decimal rate, decimal taxableAmount)
        {
            m_name = name;
            m_rate = rate;
            m_amount = rate * taxableAmount;
        }
    }
}