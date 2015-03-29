using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxMe.Models
{
    public class FederalTaxTable
    {
        private readonly FederalTaxTableEntry[] m_entries;

        public static FederalTaxTable Create(Status status)
        {
            List<FederalTaxTableEntry> entries = new List<FederalTaxTableEntry>();

            if (status == Status.MarriedFilingJointly)
            {
                entries.Add(new FederalTaxTableEntry(19450m, .1m));
                entries.Add(new FederalTaxTableEntry(56450m, .15m));
                entries.Add(new FederalTaxTableEntry(76300m, .25m));
                entries.Add(new FederalTaxTableEntry(79250m, .28m));
                entries.Add(new FederalTaxTableEntry(181050m, .33m));
                entries.Add(new FederalTaxTableEntry(53350m, .35m));
                entries.Add(new FederalTaxTableEntry(Decimal.MaxValue, .396m));
            }

            return new FederalTaxTable(entries);
        }

        public IEnumerable<FederalTaxTableEntry> Entries { get { return m_entries; } }

        private FederalTaxTable(IEnumerable<FederalTaxTableEntry> entries)
        {
            m_entries = entries.ToArray();
        }
    }
}