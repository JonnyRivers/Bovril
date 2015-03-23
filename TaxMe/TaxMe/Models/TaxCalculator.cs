using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxMe.Models
{
    public static class TaxCalculator
    {
        public static TaxBreakdown Calculate(IncomeAndDeductions incomeAndDeductions)
        {
            decimal taxableIncome = incomeAndDeductions.GrossAnnualIncome - incomeAndDeductions.TotalDeductions;
            Tax[] taxes = new Tax[] {
                GetSocialSecurityTax(taxableIncome)
            };
            TaxBreakdown taxBreakdown = new TaxBreakdown(incomeAndDeductions.GrossAnnualIncome, taxableIncome, taxes);

            return taxBreakdown;
        }

        private static Tax GetFederalIncomeTax(decimal taxableIncome)
        {
            return new Tax("Federal Income Tax", new TaxLine[0]);
        }

        private static Tax GetStateIncomeTax(decimal taxableIncome)
        {
            return new Tax("State Income Tax", new TaxLine[0]);
        }

        private static Tax GetSocialSecurityTax(decimal taxableIncome)
        {
            // NOTE: OASI and DI seem to be limited to 106,800 of taxable income :-s
            TaxLine[] lines = new TaxLine[] {
                new TaxLine("Old-Age and Survivors Insurance", .053m, taxableIncome),
                new TaxLine("Disability Insurance", .009m, taxableIncome),
                new TaxLine("Hospital Insurance", .0145m, taxableIncome)
            };

            return new Tax("Social Security", lines);
        }
    }
}