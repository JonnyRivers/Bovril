using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxMe.Models
{
    public class TaxBreakdown
    {
        private readonly decimal m_grossAnnualIncome;
        private readonly decimal m_taxableGrossAnnualIncome;
        private readonly Tax[] m_taxes;
        private readonly decimal m_totalTax;
        private readonly decimal m_netAnnualIncome;

        public decimal GrossAnnualIncome { get { return m_grossAnnualIncome; } }
        public IEnumerable<Tax> Taxes { get { return m_taxes; } }
        public decimal TotalTax { get { return m_totalTax; } }
        public decimal NetAnnualIncome { get { return m_netAnnualIncome; } }

        public TaxBreakdown(decimal grossAnnualIncome, IEnumerable<Tax> taxes)
        {
            m_grossAnnualIncome = grossAnnualIncome;
            m_taxes = taxes.ToArray();
            m_totalTax = m_taxes.Sum(tax => tax.Amount);
            m_netAnnualIncome = m_grossAnnualIncome - m_totalTax;
        }
    }
}