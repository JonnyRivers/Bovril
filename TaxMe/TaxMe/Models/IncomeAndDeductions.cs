using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxMe.Models
{
    public class IncomeAndDeductions
    {
        public decimal GrossAnnualIncome { get; set; }

        public Status Status { get; set; }

        public State State { get; set; }

        public decimal PensionContributionRate { get; set; }

        public decimal PreTaxDeductions { get; set; }

        public decimal PostTaxDeductions { get; set; }

        public decimal PensionDeduction {
            get {
                return GrossAnnualIncome * (PensionContributionRate / 100);
            }
        }

        public decimal TaxableIncome {
            get {
                return GrossAnnualIncome - PensionDeduction - PreTaxDeductions;
            }
        }
    }
}