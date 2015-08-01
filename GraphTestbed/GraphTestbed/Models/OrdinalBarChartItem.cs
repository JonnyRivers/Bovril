using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphTestbed.Models
{
    public class OrdinalBarChartItem
    {
        public OrdinalBarChartItem(String label, decimal value)
        {
            m_label = label;
            m_value = value;
        }

        public String Label { get { return m_label; } }
        public decimal Value { get { return m_value; } }

        private readonly String m_label;
        private readonly decimal m_value;
    }
}