using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxMe.Models
{
    public static class TaxCalculator
    {
        private const decimal c_federalStandardDeduction = 6300m;
        private const decimal c_federalPersonalAllowance = 4000m;

        private const decimal c_californiaStandardDeduction = 3992m;

        private const decimal c_socialSecurityTaxableLimit = 118500m;

        private const decimal c_californiaStateDisabilityInsuranceTaxableLimit = 104378m;

        public static TaxBreakdown Calculate(IncomeAndDeductions incomeAndDeductions)
        {
            Tax[] taxes = new Tax[] {
                GetFederalIncomeTax(incomeAndDeductions),
                GetStateIncomeTax(incomeAndDeductions),
                GetSocialSecurityTax(incomeAndDeductions),
                GetMedicareTax(incomeAndDeductions),
                GetStateDisabilityInsuranceTax(incomeAndDeductions)
            };
            TaxBreakdown taxBreakdown = new TaxBreakdown(
                incomeAndDeductions.GrossAnnualIncome, 
                incomeAndDeductions.PensionDeduction, 
                incomeAndDeductions.PreTaxDeductions, 
                taxes, 
                incomeAndDeductions.PostTaxDeductions);

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

            decimal taxableIncome = incomeAndDeductions.TaxableIncome - 
                (c_federalStandardDeduction * numStandardDeductions) - 
                (c_federalPersonalAllowance * numPersonalAllowances);

            List<TaxLine> taxLines = new List<TaxLine>();
            TaxTable taxTable = TaxTable.CreateFederalTaxTable(incomeAndDeductions.Status);
            foreach (TaxTableEntry entry in taxTable.Entries)
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
            int numStandardDeductions = 0;

            if (incomeAndDeductions.Status == Status.MarriedFilingJointly)
            {
                numStandardDeductions = 1;
            }

            decimal taxableIncome = incomeAndDeductions.TaxableIncome -
                (c_californiaStandardDeduction * numStandardDeductions);

            List<TaxLine> taxLines = new List<TaxLine>();
            TaxTable taxTable = TaxTable.CreateCaliforniaTaxTable(incomeAndDeductions.Status);
            foreach (TaxTableEntry entry in taxTable.Entries)
            {
                if (taxableIncome > 0)
                {
                    decimal taxableAtThisEntry = Math.Min(entry.Limit, taxableIncome);
                    taxLines.Add(
                        new TaxLine(
                            String.Format("California State at {0}%", (entry.Rate * 100).ToString("0.00")),
                            entry.Rate,
                            taxableAtThisEntry));

                    taxableIncome -= taxableAtThisEntry;
                }
            }

            return new Tax("California State Income Tax", taxLines);
        }

        private static Tax GetSocialSecurityTax(IncomeAndDeductions incomeAndDeductions)
        {
            decimal oasiTaxable = Math.Min(incomeAndDeductions.TaxableIncome, c_socialSecurityTaxableLimit);
            decimal diTaxable = Math.Min(incomeAndDeductions.TaxableIncome, c_socialSecurityTaxableLimit);

            TaxLine[] lines = new TaxLine[] {
                new TaxLine("Old-Age and Survivors Insurance", .053m, oasiTaxable),
                new TaxLine("Disability Insurance", .009m, diTaxable)
            };

            return new Tax("Social Security", lines);
        }

        private static Tax GetMedicareTax(IncomeAndDeductions incomeAndDeductions)
        {
            TaxLine[] lines = new TaxLine[] {
                new TaxLine("Hospital Insurance", .0145m, incomeAndDeductions.TaxableIncome)
            };

            return new Tax("Medicare", lines);
        }

        private static Tax GetStateDisabilityInsuranceTax(IncomeAndDeductions incomeAndDeductions)
        {
            decimal sdiTaxable = Math.Min(incomeAndDeductions.TaxableIncome, c_californiaStateDisabilityInsuranceTaxableLimit);

            TaxLine[] lines = new TaxLine[] {
                new TaxLine("State Disability Insurance", .009m, sdiTaxable)
            };

            return new Tax("State Disability Insurance Tax", lines);
        }
    }
}