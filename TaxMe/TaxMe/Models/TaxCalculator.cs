using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxMe.Models
{
    public static class TaxCalculator
    {
        private const decimal c_standardDeduction = 6300m;
        private const decimal c_personalAllowance = 4000m;

        private const decimal c_socialSecurityTaxableLimit = 118500m;

        public static TaxBreakdown Calculate(IncomeAndDeductions incomeAndDeductions)
        {
            Tax[] taxes = new Tax[] {
                GetFederalIncomeTax(incomeAndDeductions),
                GetSocialSecurityTax(incomeAndDeductions)
            };
            TaxBreakdown taxBreakdown = new TaxBreakdown(incomeAndDeductions.GrossAnnualIncome, taxes);

            return taxBreakdown;
        }

        private static Tax GetFederalIncomeTax(IncomeAndDeductions incomeAndDeductions)
        {
            int numStandardDeductions = 0;
            int numPersonalAllowances = 0;
            
            if (incomeAndDeductions.Status == Status.MarriedFilingJointly) {
                numStandardDeductions = 2;
                numPersonalAllowances = 2;
            }

            decimal taxableIncome = incomeAndDeductions.GrossAnnualIncome - 
                (c_standardDeduction * numStandardDeductions) - 
                (c_personalAllowance * numPersonalAllowances);

            List<TaxLine> taxLines = new List<TaxLine>();
            FederalTaxTable taxTable = FederalTaxTable.Create(incomeAndDeductions.Status);
            foreach (FederalTaxTableEntry entry in taxTable.Entries)
            {
                if(taxableIncome > 0)
                {
                    decimal taxableAtThisEntry = Math.Min(entry.Limit, taxableIncome);
                    taxLines.Add(
                        new TaxLine(
                            String.Format("Federal at {0}%", (entry.Rate * 100).ToString("0.00")), 
                            entry.Rate, 
                            taxableAtThisEntry));

                    taxableIncome -= taxableAtThisEntry;
                }
            }

            return new Tax("Federal Income Tax", taxLines);
        }

        private static Tax GetStateIncomeTax(IncomeAndDeductions incomeAndDeductions)
        {
            return new Tax("State Income Tax", new TaxLine[0]);
        }

        private static Tax GetSocialSecurityTax(IncomeAndDeductions incomeAndDeductions)
        {
            decimal oasiTaxable = Math.Max(incomeAndDeductions.GrossAnnualIncome, c_socialSecurityTaxableLimit);
            decimal diTaxable = Math.Max(incomeAndDeductions.GrossAnnualIncome, c_socialSecurityTaxableLimit);

            TaxLine[] lines = new TaxLine[] {
                new TaxLine("Old-Age and Survivors Insurance", .053m, oasiTaxable),
                new TaxLine("Disability Insurance", .009m, diTaxable),
                new TaxLine("Hospital Insurance", .0145m, incomeAndDeductions.GrossAnnualIncome)
            };

            return new Tax("Social Security", lines);
        }
    }
}