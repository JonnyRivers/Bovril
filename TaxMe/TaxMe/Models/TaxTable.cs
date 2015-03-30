using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxMe.Models
{
    public class TaxTable
    {
        private readonly TaxTableEntry[] m_entries;

        public static TaxTable CreateFederalTaxTable(Status status)
        {
            List<TaxTableEntry> entries = new List<TaxTableEntry>();

            if (status == Status.MarriedFilingJointly)
            {
                entries.Add(new TaxTableEntry(19450m, .1m));
                entries.Add(new TaxTableEntry(56450m, .15m));
                entries.Add(new TaxTableEntry(76300m, .25m));
                entries.Add(new TaxTableEntry(79250m, .28m));
                entries.Add(new TaxTableEntry(181050m, .33m));
                entries.Add(new TaxTableEntry(53350m, .35m));
                entries.Add(new TaxTableEntry(Decimal.MaxValue, .396m));
            }

            return new TaxTable(entries);
        }

        public static TaxTable CreateCaliforniaTaxTable(Status status)
        {
            List<TaxTableEntry> entries = new List<TaxTableEntry>();

            if (status == Status.MarriedFilingJointly)
            {
                entries.Add(new TaxTableEntry(15498m, .011m));
                entries.Add(new TaxTableEntry(21244m, .022m));
                entries.Add(new TaxTableEntry(21248m, .044m));
                entries.Add(new TaxTableEntry(22510m, .066m));
                entries.Add(new TaxTableEntry(21238m, .088m));
                entries.Add(new TaxTableEntry(417950m, .10230m));
                entries.Add(new TaxTableEntry(103936m, .1133m));
                entries.Add(new TaxTableEntry(376376m, .1243m));
                entries.Add(new TaxTableEntry(39374m, .1353m));
                entries.Add(new TaxTableEntry(Decimal.MaxValue, .1463m));
            }

            return new TaxTable(entries);
        }

        public IEnumerable<TaxTableEntry> Entries { get { return m_entries; } }

        private TaxTable(IEnumerable<TaxTableEntry> entries)
        {
            m_entries = entries.ToArray();
        }
    }
}