using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxMe.Models
{
    public class TaxBreakdown
    {
        private readonly decimal m_grossAnnualIncome;
        private readonly decimal m_pensionDeduction;
        private readonly decimal m_preTaxDeductions;
        private readonly Tax[] m_taxes;
        private readonly decimal m_totalTax;
        private readonly decimal m_postTaxDeductions;
        private readonly decimal m_netAnnualIncome;

        public decimal GrossAnnualIncome { get { return m_grossAnnualIncome; } }
        public decimal PensionDeduction { get { return m_pensionDeduction; } }
        public decimal PreTaxDeductions { get { return m_preTaxDeductions; } }
        public IEnumerable<Tax> Taxes { get { return m_taxes; } }
        public decimal TotalTax { get { return m_totalTax; } }
        public decimal PostTaxDeductions { get { return m_postTaxDeductions; } }
        public decimal NetAnnualIncome { get { return m_netAnnualIncome; } }

        public decimal TaxableIncome {
            get {
                return GrossAnnualIncome - PensionDeduction - PreTaxDeductions;
            }
        }

        public TaxBreakdown(decimal grossAnnualIncome, decimal pensionDeduction, decimal preTaxDeductions, IEnumerable<Tax> taxes, decimal postTaxDeductions)
        {
            m_grossAnnualIncome = grossAnnualIncome;
            m_pensionDeduction = pensionDeduction;
            m_preTaxDeductions = preTaxDeductions;
            m_taxes = taxes.ToArray();
            m_totalTax = m_taxes.Sum(tax => tax.Amount);
            m_postTaxDeductions = postTaxDeductions;
            m_netAnnualIncome = TaxableIncome - m_totalTax - postTaxDeductions;
        }
    }
}